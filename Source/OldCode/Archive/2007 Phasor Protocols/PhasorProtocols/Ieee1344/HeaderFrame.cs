//*******************************************************************************************************
//  HeaderFrame.cs
//  Copyright © 2009 - TVA, all rights reserved - Gbtc
//
//  Build Environment: C#, Visual Studio 2008
//  Primary Developer: James R Carroll
//      Office: PSO TRAN & REL, CHATTANOOGA - MR BK-C
//       Phone: 423/751-4165
//       Email: jrcarrol@tva.gov
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  01/14/2005 - James R Carroll
//       Generated original version of source code.
//
//*******************************************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Security.Permissions;
using PCS.IO.Checksums;
using PCS.Parsing;

namespace PCS.PhasorProtocols.Ieee1344
{
    /// <summary>
    /// Represents the IEEE 1344 implementation of a <see cref="IHeaderFrame"/> that can be sent or received.
    /// </summary>
    [Serializable()]
    public class HeaderFrame : HeaderFrameBase, ISupportFrameImage<FrameType>
    {
        #region [ Members ]

        // Fields
        private CommonFrameHeader m_frameHeader;
        private ulong m_idCode;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="HeaderFrame"/>.
        /// </summary>
        /// <remarks>
        /// This constructor is used by a consumer to generate an IEEE 1344 configuration frame and by the
        /// <see cref="FrameImageParserBase{TTypeIdentifier,TOutputType}"/> to parse an IEEE 1344 configuration frame.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HeaderFrame()
            : base(new HeaderCellCollection(Common.MaximumDataLength - 1))
        {
        }

        /// <summary>
        /// Creates a new <see cref="HeaderFrame"/> from serialization parameters.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> with populated with data.</param>
        /// <param name="context">The source <see cref="StreamingContext"/> for this deserialization.</param>
        protected HeaderFrame(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Deserialize header frame
            m_frameHeader = (CommonFrameHeader)info.GetValue("frameHeader", typeof(CommonFrameHeader));
            m_idCode = info.GetUInt64("idCode64Bit");
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets the ID code of this <see cref="HeaderFrame"/>.
        /// </summary>
        public new ulong IDCode
        {
            get
            {
                return m_idCode;
            }
            set
            {
                m_idCode = value;

                // Base classes constrain maximum value to 65535
                base.IDCode = value > ushort.MaxValue ? ushort.MaxValue : (ushort)value;
            }
        }

        /// <summary>
        /// Gets or sets exact timestamp, in ticks, of the data represented by this <see cref="HeaderFrame"/>.
        /// </summary>
        /// <remarks>
        /// The value of this property represents the number of 100-nanosecond intervals that have elapsed since 12:00:00 midnight, January 1, 0001.
        /// </remarks>
        public override Ticks Timestamp
        {
            get
            {
                return CommonHeader.Timestamp;
            }
            set
            {
                // Keep timestamp updates synchrnonized...
                CommonHeader.Timestamp = value;
                base.Timestamp = value;
            }
        }

        /// <summary>
        /// Gets the timestamp of this frame in NTP format.
        /// </summary>
        public new NtpTimeTag TimeTag
        {
            get
            {
                return CommonHeader.TimeTag;
            }
        }

        /// <summary>
        /// Gets the identifier that is used to identify the IEEE 1344 frame.
        /// </summary>
        public FrameType TypeID
        {
            get
            {
                return Ieee1344.FrameType.HeaderFrame;
            }
        }

        /// <summary>
        /// Gets or sets current <see cref="CommonFrameHeader"/>.
        /// </summary>
        public CommonFrameHeader CommonHeader
        {
            get
            {
                // Make sure frame header exists - using base class timestamp to
                // prevent recursion (m_frameHeader doesn't exist yet)
                if (m_frameHeader == null)
                    m_frameHeader = new CommonFrameHeader(TypeID, base.Timestamp);

                return m_frameHeader;
            }
            set
            {
                m_frameHeader = value;

                if (m_frameHeader != null)
                {
                    State = m_frameHeader.State as IHeaderFrameParsingState;
                    base.Timestamp = m_frameHeader.Timestamp;
                }
            }
        }

        // This interface implementation satisfies ISupportFrameImage<FrameType>.CommonHeader
        ICommonHeader<FrameType> ISupportFrameImage<FrameType>.CommonHeader
        {
            get
            {
                return CommonHeader;
            }
            set
            {
                CommonHeader = value as CommonFrameHeader;
            }
        }

        /// <summary>
        /// Gets the length of the <see cref="HeaderImage"/>.
        /// </summary>
        protected override int HeaderLength
        {
            get
            {
                return CommonFrameHeader.FixedLength;
            }
        }

        /// <summary>
        /// Gets the binary header image of the <see cref="HeaderFrame"/> object.
        /// </summary>
        protected override byte[] HeaderImage
        {
            get
            {
                // Make sure to provide proper frame length for use in the common header image
                unchecked
                {
                    CommonHeader.FrameLength = (ushort)BinaryLength;
                }

                return CommonHeader.BinaryImage;
            }
        }

        /// <summary>
        /// <see cref="Dictionary{TKey,TValue}"/> of string based property names and values for the <see cref="HeaderFrame"/> object.
        /// </summary>
        public override Dictionary<string, string> Attributes
        {
            get
            {
                Dictionary<string, string> baseAttributes = base.Attributes;

                CommonHeader.AppendHeaderAttributes(baseAttributes);

                baseAttributes.Add("64-Bit ID Code", IDCode.ToString());

                return baseAttributes;
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Parses the binary image.
        /// </summary>
        /// <param name="binaryImage">Binary image to parse.</param>
        /// <param name="startIndex">Start index into <paramref name="binaryImage"/> to begin parsing.</param>
        /// <param name="length">Length of valid data within <paramref name="binaryImage"/>.</param>
        /// <returns>The length of the data that was parsed.</returns>
        /// <remarks>
        /// This method is overriden to parse from cumulated frame images.
        /// </remarks>
        public override int Initialize(byte[] binaryImage, int startIndex, int length)
        {
            // If frame image collector was used, make sure and parse from entire frame image...
            if (m_frameHeader != null)
            {
                // If all header frame images have been received, we can safely start parsing
                if (m_frameHeader.IsLastFrame)
                {
                    FrameImageCollector frameImages = m_frameHeader.FrameImages;

                    if (frameImages != null)
                    {
                        // Each individual frame will already have had a CRC check, so we implement standard parse to
                        // bypass ChannelBase CRC frame validation on cumulative frame image
                        binaryImage = frameImages.BinaryImage;
                        length = frameImages.BinaryLength;
                        startIndex = 0;

                        // Parse out header, body and footer images
                        startIndex += ParseHeaderImage(binaryImage, startIndex, length);
                        startIndex += ParseBodyImage(binaryImage, startIndex, length - startIndex);
                        startIndex += ParseFooterImage(binaryImage, startIndex, length - startIndex);

                        // Include 2 bytes for CRC that was already validated
                        return startIndex + 2;
                    }
                }

                // There are more header frame images coming, keep parser moving by returning total
                // frame length that was already parsed.
                return State.ParsedBinaryLength;
            }

            return base.Initialize(binaryImage, startIndex, length);
        }

        /// <summary>
        /// Parses the binary header image.
        /// </summary>
        /// <param name="binaryImage">Binary image to parse.</param>
        /// <param name="startIndex">Start index into <paramref name="binaryImage"/> to begin parsing.</param>
        /// <param name="length">Length of valid data within <paramref name="binaryImage"/>.</param>
        /// <returns>The length of the data that was parsed.</returns>
        protected override int ParseHeaderImage(byte[] binaryImage, int startIndex, int length)
        {
            // We already parsed the frame header, so we just skip past it...
            return CommonFrameHeader.FixedLength;
        }

        /// <summary>
        /// Calculates checksum of given <paramref name="buffer"/>.
        /// </summary>
        /// <param name="buffer">Buffer image over which to calculate checksum.</param>
        /// <param name="offset">Start index into <paramref name="buffer"/> to calculate checksum.</param>
        /// <param name="length">Length of data within <paramref name="buffer"/> to calculate checksum.</param>
        /// <returns>Checksum over specified portion of <paramref name="buffer"/>.</returns>
        protected override ushort CalculateChecksum(byte[] buffer, int offset, int length)
        {
            // IEEE 1344 uses CRC16 to calculate checksum for frames
            return buffer.Crc16Checksum(offset, length);
        }

        /// <summary>
        /// Populates a <see cref="SerializationInfo"/> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> to populate with data.</param>
        /// <param name="context">The destination <see cref="StreamingContext"/> for this serialization.</param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            // Serialize configuration frame
            info.AddValue("frameHeader", m_frameHeader, typeof(CommonFrameHeader));
            info.AddValue("idCode64Bit", m_idCode);
        }

        #endregion
    }
}