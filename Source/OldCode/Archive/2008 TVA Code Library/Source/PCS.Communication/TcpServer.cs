//*******************************************************************************************************
//  TcpServer.cs
//  Copyright © 2008 - TVA, all rights reserved - Gbtc
//
//  Build Environment: C#, Visual Studio 2008
//  Primary Developer: Pinal C. Patel, Operations Data Architecture [PCS]
//      Office: PSO TRAN & REL, CHATTANOOGA - MR BK-C
//       Phone: 423/751-3024
//       Email: pcpatel@tva.gov
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  06/02/2006 - Pinal C. Patel
//       Original version of source code generated
//  09/06/2006 - J. Ritchie Carroll
//       Added bypass optimizations for high-speed socket access
//  12/01/2006 - Pinal C. Patel
//       Modified code for handling "PayloadAware" transmissions
//  01/28/3008 - J. Ritchie Carroll
//       Placed accepted TCP socket connections on their own threads instead of thread pool
//  09/29/2008 - James R Carroll
//       Converted to C#.
//
//*******************************************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Sockets;
using System.Threading;
using PCS.Security.Cryptography;

namespace PCS.Communication
{
    /// <summary>
    /// Represents a TCP-based communication server.
    /// </summary>
    /// <remarks>
    /// "Payload-Aware" enabled transmission can transmit up to 100MB of payload in a single transmission.
    /// </remarks>
    /// <example>
    /// 
    /// <code>
    /// using System;
    /// using PCS.Communication;
    /// using PCS.Security.Cryptography;
    /// using PCS.IO.Compression;
    /// 
    /// class Program
    /// {
    ///     static TcpServer m_server;
    /// 
    ///     static void Main(string[] args)
    ///     {
    ///         // Initialize the server.
    ///         m_server = new TcpServer("Port=8888");
    ///         m_server.Handshake = false;
    ///         m_server.PayloadAware = true;
    ///         m_server.ReceiveTimeout = -1;
    ///         //m_server.Encryption = CipherStrength.Level1;
    ///         //m_server.Compression = CompressionStrength.BestSpeed;
    ///         //m_server.SecureSession = true;
    ///         // Register event handlers.
    ///         m_server.ServerStarted += m_server_ServerStarted;
    ///         m_server.ServerStopped += m_server_ServerStopped;
    ///         m_server.ClientConnected += m_server_ClientConnected;
    ///         m_server.ClientDisconnected += m_server_ClientDisconnected;
    ///         m_server.ReceiveClientDataComplete += m_server_ReceiveClientDataComplete;
    ///         // Start the server.
    ///         m_server.Start();
    /// 
    ///         string input;
    ///         while (string.Compare(input = Console.ReadLine(), "Exit", true) != 0)
    ///         {
    ///             m_server.Multicast(System.IO.File.ReadAllText(@"C:\My Projects\CLR 3.5\Win\TVACodeLibrary\Source\TVA.Core\Collections\KeyedProcessQueue.vb"));
    ///         }
    /// 
    ///         m_server.Stop();
    ///     }
    /// 
    ///     static void m_server_ServerStarted(object sender, EventArgs e)
    ///     {
    ///         Console.WriteLine("Server has been started!");
    ///     }
    /// 
    ///     static void m_server_ServerStopped(object sender, EventArgs e)
    ///     {
    ///         Console.WriteLine("Server has been stopped!");
    ///     }
    /// 
    ///     static void m_server_ClientConnected(object sender, EventArgs&lt;Guid&gt; e)
    ///     {
    ///         Console.WriteLine(string.Format("Client connected - {0}.", e.Argument));
    ///     }
    /// 
    ///     static void m_server_ClientDisconnected(object sender, EventArgs&lt;Guid&gt; e)
    ///     {
    ///         Console.WriteLine(string.Format("Client disconnected - {0}.", e.Argument));
    ///     }
    /// 
    ///     static void m_server_ReceiveClientDataComplete(object sender, EventArgs&lt;Guid, byte[], int&gt; e)
    ///     {
    ///         Console.WriteLine(string.Format("Received data from {0} - {1}.", e.Argument1, m_server.TextEncoding.GetString(e.Argument2, 0, e.Argument3)));
    ///     }
    /// }
    /// </code>
    /// </example>
    public class TcpServer : ServerBase
    {
        #region [ Members ]

        // Constants

        /// <summary>
        /// Specifies the default value for the <see cref="ServerBase.ConfigurationString"/> property.
        /// </summary>
        public const string DefaultConfigurationString = "Port=8888";

        /// <summary>
        /// Specifies the default value for the <see cref="PayloadAware"/> property.
        /// </summary>
        public const bool DefaultPayloadAware = false;

        // Fields
        private bool m_payloadAware;
        private byte[] m_payloadMarker;
        private Socket m_tcpServer;
        private Dictionary<string, string> m_configData;
        private Dictionary<Guid, TransportProvider<Socket>> m_tcpClients;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Initializes a new instance of the <see cref="TcpServer"/> class.
        /// </summary>
        public TcpServer()
            : this(DefaultConfigurationString)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TcpServer"/> class.
        /// </summary>
        /// <param name="configString">Config string of the server. See <see cref="DefaultConfigurationString"/> for format.</param>
        public TcpServer(string configString)
            : base(TransportProtocol.Tcp, configString)
        {
            m_payloadAware = DefaultPayloadAware;
            m_payloadMarker = Payload.DefaultMarker;
            m_tcpClients = new Dictionary<Guid, TransportProvider<Socket>>();
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets a boolean value that indicates whether the payload boundaries are to be preserved during transmission.
        /// </summary>
        /// <remarks>This property must be set to True if either <see cref="ServerBase.Encryption"/> or <see cref="ServerBase.Compression"/> is enabled.</remarks>
        [Category("Data"),
        DefaultValue(DefaultPayloadAware),
        Description("Indicates whether the payload boundaries are to be preserved during transmission.")]
        public bool PayloadAware
        {
            get
            {
                return m_payloadAware;
            }
            set
            {
                m_payloadAware = value;
            }
        }

        /// <summary>
        /// Gets or sets the byte sequence used to mark the beginning of a payload in a <see cref="PayloadAware"/> transmission.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value specified is null or empty buffer.</exception>
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public byte[] PayloadMarker
        {
            get
            {
                return m_payloadMarker;
            }
            set
            {
                if (value == null || value.Length == 0)
                    throw new ArgumentNullException();

                m_payloadMarker = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="Socket"/> object for the <see cref="TcpServer"/>.
        /// </summary>
        [Browsable(false)]
        public Socket ServerSocket
        {
            get
            {
                return m_tcpServer;
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Stops the <see cref="TcpServer"/> synchronously and disconnects all connected clients.
        /// </summary>
        public override void Stop()
        {
            if (IsRunning)
            {
                m_tcpServer.Close();    // Stop accepting new connections.
                DisconnectAll();        // Disconnection all connection clients.
            }
        }

        /// <summary>
        /// Starts the <see cref="TcpServer"/> synchronously and begins accepting client connections asynchronously.
        /// </summary>
        /// <exception cref="InvalidOperationException">Attempt is made to <see cref="Start()"/> the <see cref="TcpServer"/> when it is running.</exception>
        public override void Start()
        {
            if (!IsRunning)
            {
                // Initialize if unitialized.
                Initialize();
                // Bind server socket to local end-point and listen.
                m_tcpServer = Transport.CreateSocket(int.Parse(m_configData["port"]), ProtocolType.Tcp);
                m_tcpServer.Listen(1);
                // Begin accepting incoming connection asynchronously.
                m_tcpServer.BeginAccept(AcceptAsyncCallback, null);
                // Notify that the server has been started successfully.
                OnServerStarted();
            }
            else 
            {
                throw new InvalidOperationException("Server is currently running.");
            }
        }

        /// <summary>
        /// Disconnects the specified connected client.
        /// </summary>
        /// <param name="clientID">ID of the client to be disconnected.</param>
        /// <exception cref="InvalidOperationException">Client does not exist for the specified <paramref name="clientID"/>.</exception>
        public override void DisconnectOne(Guid clientID)
        {
            ClientSocket(clientID).Provider.Close();
        }

        /// <summary>
        /// Gets the <see cref="TransportProvider{Socket}"/> object associated with the specified client ID.
        /// </summary>
        /// <param name="clientID">ID of the client.</param>
        /// <returns>An <see cref="TransportProvider{Socket}"/> object.</returns>
        /// <exception cref="InvalidOperationException">Client does not exist for the specified <paramref name="clientID"/>.</exception>
        public TransportProvider<Socket> ClientSocket(Guid clientID)
        {
            TransportProvider<Socket> tcpClient;
            lock (m_tcpClients)
            {
                if (m_tcpClients.TryGetValue(clientID, out tcpClient))
                    return tcpClient;
                else
                    throw new InvalidOperationException(string.Format("No client exists for Client ID \"{0}\".", clientID));
            }
        }

        /// <summary>
        /// Validates the specified <paramref name="configurationString"/>.
        /// </summary>
        /// <param name="configurationString">Configuration string to be validated.</param>
        /// <exception cref="ArgumentException">Port property is missing.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Port property value is not between <see cref="Transport.PortRangeLow"/> and <see cref="Transport.PortRangeHigh"/>.</exception>
        protected override void ValidateConfigurationString(string configurationString)
        {
            m_configData = configurationString.ParseKeyValuePairs();

            if (!m_configData.ContainsKey("port"))
                throw new ArgumentException(string.Format("Port is missing. Example: {0}.", DefaultConfigurationString));

            if (!Transport.IsPortNumberValid(m_configData["port"]))
                throw new ArgumentOutOfRangeException("configurationString", string.Format("Port number must between {0} and {1}.", Transport.PortRangeLow, Transport.PortRangeHigh));
        }

        /// <summary>
        /// Gets the passphrase to be used for ciphering client data.
        /// </summary>
        /// <param name="clientID">ID of the client whose passphrase is to be retrieved.</param>
        /// <returns>Cipher passphrase of the client with the specified <paramref name="clientID"/>.</returns>
        protected override string GetSessionPassphrase(Guid clientID)
        {
            return ClientSocket(clientID).Passphrase;
        }

        /// <summary>
        /// Sends data to the specified client asynchronously.
        /// </summary>
        /// <param name="clientID">ID of the client to which the data is to be sent.</param>
        /// <param name="data">The buffer that contains the binary data to be sent.</param>
        /// <param name="offset">The zero-based position in the <paramref name="data"/> at which to begin sending data.</param>
        /// <param name="length">The number of bytes to be sent from <paramref name="data"/> starting at the <paramref name="offset"/>.</param>
        /// <returns><see cref="WaitHandle"/> for the asynchronous operation.</returns>
        protected override WaitHandle SendDataToAsync(Guid clientID, byte[] data, int offset, int length)
        {
            WaitHandle handle;
            TransportProvider<Socket> tcpClient = ClientSocket(clientID);

            // Prepare for payload-aware transmission.
            if (m_payloadAware)
                Payload.AddHeader(ref data, ref offset, ref length, m_payloadMarker);

            // Send payload to the client asynchronously.
            tcpClient.SendBuffer = data;
            tcpClient.SendBufferOffset = offset;
            tcpClient.SendBufferLength = length;
            handle = tcpClient.Provider.BeginSend(tcpClient.SendBuffer, tcpClient.SendBufferOffset, tcpClient.SendBufferLength, SocketFlags.None, SendPayloadAsyncCallback, tcpClient).AsyncWaitHandle;
            OnSendClientDataStart(tcpClient.ID);

            // Return the async handle that can be used to wait for the async operation to complete.
            return handle;
        }

        /// <summary>
        /// Callback method for asynchronous accept operation.
        /// </summary>
        private void AcceptAsyncCallback(IAsyncResult asyncResult)
        {
            TransportProvider<Socket> tcpClient = new TransportProvider<Socket>();
            try
            {
                // Return to accepting new connections.
                m_tcpServer.BeginAccept(AcceptAsyncCallback, null);
                // Process the newly connected client.
                tcpClient.Passphrase = HandshakePassphrase;
                tcpClient.Provider = m_tcpServer.EndAccept(asyncResult);
                if (MaxClientConnections != -1 && ClientIDs.Length >= MaxClientConnections)
                {
                    // Reject client connection since limit has been reached.
                    TerminateConnection(tcpClient, false);
                }
                else
                {
                    // We can proceed further with receiving data from the client.
                    if (Handshake)
                    {
                        // Handshaking must be performed. 
                        ReceiveHandshakeAsync(tcpClient);
                    }
                    else
                    {
                        // No handshaking to be performed.
                        lock (m_tcpClients)
                        {
                            m_tcpClients.Add(tcpClient.ID, tcpClient);
                        }
                        OnClientConnected(tcpClient.ID);
                        ReceivePayloadAsync(tcpClient);
                    }
                }
            }
            catch
            {
                // Server socket has been terminated.
                m_tcpServer.Close();
                OnServerStopped();
            }
        }

        /// <summary>
        /// Callback method for asynchronous send operation.
        /// </summary>
        private void SendPayloadAsyncCallback(IAsyncResult asyncResult)
        {
            TransportProvider<Socket> tcpClient = asyncResult.AsyncState as TransportProvider<Socket>;
            try
            {
                // Send operation is complete.
                tcpClient.Statistics.UpdateBytesSent(tcpClient.Provider.EndSend(asyncResult));
                OnSendClientDataComplete(tcpClient.ID);
            }
            catch (Exception ex)
            {
                // Send operation failed to complete.
                OnSendClientDataException(tcpClient.ID, ex);
            }
        }

        /// <summary>
        /// Initiate method for receving handshake data.
        /// </summary>
        private void ReceiveHandshakeAsync(TransportProvider<Socket> worker)
        {
            // Prepare buffer used for receiving data.
            worker.ReceiveBufferOffset = 0;
            worker.ReceiveBufferLength = -1;
            worker.ReceiveBuffer = new byte[ReceiveBufferSize];
            // Receive data asynchronously with a timeout.
            worker.WaitAsync(HandshakeTimeout,
                             ReceiveHandshakeAsyncCallback,
                             worker.Provider.BeginReceive(worker.ReceiveBuffer,
                                                          worker.ReceiveBufferOffset,
                                                          worker.ReceiveBuffer.Length,
                                                          SocketFlags.None,
                                                          ReceiveHandshakeAsyncCallback,
                                                          worker));
        }

        /// <summary>
        /// Callback method for asynchronous receive operation of handshake data.
        /// </summary>
        private void ReceiveHandshakeAsyncCallback(IAsyncResult asyncResult)
        {
            TransportProvider<Socket> tcpClient = asyncResult.AsyncState as TransportProvider<Socket>;
            if (!asyncResult.IsCompleted)
            {
                // Handshake didn't complete in a timely fashion.
                TerminateConnection(tcpClient, false);
                OnHandshakeProcessTimeout();
            }
            else
            {
                // Received handshake data from client so we'll process it.
                try
                {
                    // Update statistics and pointers.
                    tcpClient.Statistics.UpdateBytesReceived(tcpClient.Provider.EndReceive(asyncResult));
                    tcpClient.ReceiveBufferLength = tcpClient.Statistics.LastBytesReceived;

                    if (tcpClient.Statistics.LastBytesReceived == 0)
                        // Client disconnected gracefully.
                        throw new SocketException((int)SocketError.Disconnecting);

                    // Process the received handshake message.
                    Payload.ProcessReceived(ref tcpClient.ReceiveBuffer, ref tcpClient.ReceiveBufferOffset, ref tcpClient.ReceiveBufferLength, Encryption, HandshakePassphrase, Compression);

                    HandshakeMessage handshake = new HandshakeMessage();
                    if (handshake.Initialize(tcpClient.ReceiveBuffer, tcpClient.ReceiveBufferOffset, tcpClient.ReceiveBufferLength) != -1)
                    {
                        // Received handshake message could be parsed successfully.
                        if (handshake.ID != Guid.Empty && handshake.Passphrase == HandshakePassphrase)
                        {
                            // Authentication is successful; respond to the handshake.
                            tcpClient.ID = handshake.ID;
                            handshake.ID = this.ServerID;
                            if (SecureSession)
                            {
                                // Create a secret key for ciphering client data.
                                tcpClient.Passphrase = Cipher.GenerateKey();
                                handshake.Passphrase = tcpClient.Passphrase;
                            }

                            // Prepare binary image of handshake response to be transmitted.
                            tcpClient.SendBuffer = handshake.BinaryImage;
                            tcpClient.SendBufferOffset = 0;
                            tcpClient.SendBufferLength = tcpClient.SendBuffer.Length;
                            Payload.ProcessTransmit(ref tcpClient.SendBuffer, ref tcpClient.SendBufferOffset, ref tcpClient.SendBufferLength, Encryption, HandshakePassphrase, Compression);

                            // Transmit the prepared and processed handshake response message.
                            tcpClient.Provider.Send(tcpClient.SendBuffer, tcpClient.SendBufferOffset, tcpClient.SendBufferLength, SocketFlags.None);

                            // Handshake process is complete and client is considered connected.
                            lock (m_tcpClients)
                            {
                                m_tcpClients.Add(tcpClient.ID, tcpClient);
                            }
                            OnClientConnected(tcpClient.ID);
                            ReceivePayloadAsync(tcpClient);
                        }
                        else
                        {
                            // Authentication during handshake failed, so we terminate the client connection.
                            TerminateConnection(tcpClient, false);
                            OnHandshakeProcessUnsuccessful();
                        }
                    }
                    else
                    {
                        // Handshake message could not be parsed, so we terminate the client connection.
                        TerminateConnection(tcpClient, false);
                        OnHandshakeProcessUnsuccessful();
                    }
                }
                catch
                {
                    // Handshake process could not be completed most likely due to client disconnect.
                    TerminateConnection(tcpClient, false);
                    OnHandshakeProcessUnsuccessful();
                }
            }
        }

        /// <summary>
        /// Initiate method for receiving payload data.
        /// </summary>
        private void ReceivePayloadAsync(TransportProvider<Socket> worker)
        {
            // Initialize pointers.
            worker.ReceiveBufferOffset = 0;
            worker.ReceiveBufferLength = -1;

            // Initiate receiving.
            if (m_payloadAware)
            {
                // Payload boundaries are to be preserved.
                worker.ReceiveBuffer = new byte[m_payloadMarker.Length + Payload.LengthSegment];
                ReceivePayloadAwareAsync(worker);
            }
            else
            {
                // Payload boundaries are not to be preserved.
                worker.ReceiveBuffer = new byte[ReceiveBufferSize];
                ReceivePayloadUnawareAsync(worker);
            }
        }

        /// <summary>
        /// Initiate method for receiving payload data in "payload-aware" mode.
        /// </summary>
        private void ReceivePayloadAwareAsync(TransportProvider<Socket> worker)
        {
            if (ReceiveTimeout == -1)
            {
                // Wait for data indefinitely.
                worker.Provider.BeginReceive(worker.ReceiveBuffer,
                                             worker.ReceiveBufferOffset,
                                             worker.ReceiveBuffer.Length - worker.ReceiveBufferOffset,
                                             SocketFlags.None,
                                             ReceivePayloadAwareAsyncCallback,
                                             worker);
            }
            else
            {
                // Wait for data with a timeout.
                worker.WaitAsync(ReceiveTimeout,
                                 ReceivePayloadAwareAsyncCallback,
                                 worker.Provider.BeginReceive(worker.ReceiveBuffer,
                                                              worker.ReceiveBufferOffset,
                                                              worker.ReceiveBuffer.Length - worker.ReceiveBufferOffset,
                                                              SocketFlags.None,
                                                              ReceivePayloadAwareAsyncCallback,
                                                              worker));
            }

        }

        /// <summary>
        /// Callback method for asynchronous receive operation of payload data in "payload-aware" mode.
        /// </summary>
        private void ReceivePayloadAwareAsyncCallback(IAsyncResult asyncResult)
        {
            TransportProvider<Socket> tcpClient = asyncResult.AsyncState as TransportProvider<Socket>;
            if (!asyncResult.IsCompleted)
            {
                // Timedout on reception of data so notify via event and continue waiting for data.
                OnReceiveClientDataTimeout(tcpClient.ID);
                tcpClient.WaitAsync(ReceiveTimeout, ReceivePayloadAwareAsyncCallback, asyncResult);
            }
            else
            {
                try
                {
                    // Update statistics and pointers.
                    tcpClient.Statistics.UpdateBytesReceived(tcpClient.Provider.EndReceive(asyncResult));
                    tcpClient.ReceiveBufferOffset += tcpClient.Statistics.LastBytesReceived;

                    if (tcpClient.Statistics.LastBytesReceived == 0)
                        // Client disconnected gracefully.
                        throw new SocketException((int)SocketError.Disconnecting);

                    if (tcpClient.ReceiveBufferLength == -1)
                    {
                        // We're waiting on the payload length, so we'll check if the received data has this information.
                        tcpClient.ReceiveBufferOffset = 0;
                        tcpClient.ReceiveBufferLength = Payload.ExtractLength(tcpClient.ReceiveBuffer, m_payloadMarker);

                        if (tcpClient.ReceiveBufferLength != -1)
                        {
                            // We have the payload length, so we'll create a buffer that's big enough to hold the entire payload.
                            tcpClient.ReceiveBuffer = new byte[tcpClient.ReceiveBufferLength];
                        }

                        ReceivePayloadAwareAsync(tcpClient);
                    }
                    else
                    {
                        // We're accumulating the payload in the receive buffer until the entire payload is received.
                        if (tcpClient.ReceiveBufferOffset == tcpClient.ReceiveBufferLength)
                        {
                            // We've received the entire payload.
                            OnReceiveClientDataComplete(tcpClient.ID, tcpClient.ReceiveBuffer, tcpClient.ReceiveBufferLength);
                            ReceivePayloadAsync(tcpClient);
                        }
                        else
                        {
                            // We've not yet received the entire payload.
                            ReceivePayloadAwareAsync(tcpClient);
                        }
                    }
                }
                catch
                {
                    // Client disconnected so we'll process it's disconnect.
                    TerminateConnection(tcpClient, true);
                }
            }
        }

        /// <summary>
        /// Initiate method for receiving payload data in "payload-unaware" mode.
        /// </summary>
        private void ReceivePayloadUnawareAsync(TransportProvider<Socket> worker)
        {
            if (ReceiveTimeout == -1)
            {
                // Wait for data indefinitely.
                worker.Provider.BeginReceive(worker.ReceiveBuffer,
                                             worker.ReceiveBufferOffset,
                                             worker.ReceiveBuffer.Length - worker.ReceiveBufferOffset,
                                             SocketFlags.None,
                                             ReceivePayloadUnawareAsyncCallback,
                                             worker);
            }
            else
            {
                // Wait for data with a timeout.
                worker.WaitAsync(ReceiveTimeout,
                                 ReceivePayloadUnawareAsyncCallback,
                                 worker.Provider.BeginReceive(worker.ReceiveBuffer,
                                                              worker.ReceiveBufferOffset,
                                                              worker.ReceiveBuffer.Length - worker.ReceiveBufferOffset,
                                                              SocketFlags.None,
                                                              ReceivePayloadUnawareAsyncCallback,
                                                              worker));

            }
        }

        /// <summary>
        /// Callback method for asynchronous receive operation of payload data in "payload-unaware" mode.
        /// </summary>
        private void ReceivePayloadUnawareAsyncCallback(IAsyncResult asyncResult)
        {
            TransportProvider<Socket> tcpClient = asyncResult.AsyncState as TransportProvider<Socket>;
            if (!asyncResult.IsCompleted)
            {
                // Timedout on reception of data so notify via event and continue waiting for data.
                OnReceiveClientDataTimeout(tcpClient.ID);
                tcpClient.WaitAsync(ReceiveTimeout, ReceivePayloadUnawareAsyncCallback, asyncResult);
            }
            else
            {
                try
                {
                    // Update statistics and pointers.
                    tcpClient.Statistics.UpdateBytesReceived(tcpClient.Provider.EndReceive(asyncResult));
                    tcpClient.ReceiveBufferLength = tcpClient.Statistics.LastBytesReceived;

                    if (tcpClient.Statistics.LastBytesReceived == 0)
                        // Client disconnected gracefully.
                        throw new SocketException((int)SocketError.Disconnecting);

                    // Notify of received data and resume receive operation.
                    OnReceiveClientDataComplete(tcpClient.ID, tcpClient.ReceiveBuffer, tcpClient.ReceiveBufferLength);
                    ReceivePayloadUnawareAsync(tcpClient);
                }
                catch
                {
                    // Client disconnected so we'll process it's disconnect.
                    TerminateConnection(tcpClient, true);
                }
            }
        }

        /// <summary>
        /// Processes the termination of client.
        /// </summary>
        private void TerminateConnection(TransportProvider<Socket> client, bool raiseEvent)
        {
            client.Reset();
            if (raiseEvent)
                OnClientDisconnected(client.ID);

            lock (m_tcpClients)
            {
                if (m_tcpClients.ContainsKey(client.ID))
                    m_tcpClients.Remove(client.ID);
            }
        }

        #endregion
    }
}