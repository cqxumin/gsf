﻿//*******************************************************************************************************
//  ErrorLogger.cs
//  Copyright © 2008 - TVA, all rights reserved - Gbtc
//
//  Build Environment: C#, Visual Studio 2008
//  Primary Developer: Pinal C Patel
//      Office: INFO SVCS APP DEV, CHATTANOOGA - MR 2W-C
//       Phone: 423-751-2250
//       Email: pcpatel@tva.gov
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  04/03/2007 - Pinal C. Patel
//       Original version of source code generated.
//  11/30/2007 - Pinal C. Patel
//       Modified the "design time" check in EndInit() method to use LicenseManager.UsageMode property
//       instead of DesignMode property as the former is more accurate than the latter.
//
//*******************************************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using TVA.Configuration;
using TVA.Identity;
using TVA.IO;
using TVA.Net.Smtp;
using TVA.Reflection;

namespace TVA.ErrorManagement
{
    /// <summary>
    ///
    /// </summary>
    /// <remarks>
    /// Adapted from exception handling code by Jeff Atwood of CodingHorror.com. Demo projects for handling unhandled
    /// exception in both windows and web environment by Jeff Atwood are available at The Code Project web site.
    /// See: http://www.codeproject.com/script/articles/list_articles.asp?userid=450027
    /// </remarks>
    [ToolboxBitmap(typeof(GlobalExceptionLogger))]
    public class ErrorLogger : Component, IPersistSettings, ISupportInitialize
    {
        #region [ Members ]

        // Constants
        /// <summary>
        /// Default value for AutoRegister property.
        /// </summary>
        public const bool DefaultAutoRegister = true;

        /// <summary>
        /// Default value for ExitOnUnhandledException property.
        /// </summary>
        public const bool DefaultExitOnUnhandledException = false;

        /// <summary>
        /// Default value for LogToUI property.
        /// </summary>
        public const bool DefaultLogToUI = false;

        /// <summary>
        /// Default value for LogToFile property.
        /// </summary>
        public const bool DefaultLogToFile = true;

        /// <summary>
        /// Default value for LogToEmail property.
        /// </summary>
        public const bool DefaultLogToEmail = false;

        /// <summary>
        /// Default value for LogToEventLog property.
        /// </summary>
        public const bool DefaultLogToEventLog = true;

        /// <summary>
        /// Default value for LogToScreenshot property.
        /// </summary>
        public const bool DefaultLogToScreenshot = false;

        /// <summary>
        /// Default value for SmtpServer property.
        /// </summary>
        public const string DefaultSmtpServer = "mailhost.cha.tva.gov";

        /// <summary>
        /// Default value for ContactName property.
        /// </summary>
        public const string DefaultContactName = "";

        /// <summary>
        /// Default value for ContactEmail property.
        /// </summary>
        public const string DefaultContactEmail = "";

        /// <summary>
        /// Default value for ContactPhone property.
        /// </summary>
        public const string DefaultContactPhone = "";

        /// <summary>
        /// Default value for PersistSettings property.
        /// </summary>
        public const bool DefaultPersistSettings = false;

        /// <summary>
        /// Default value for SettingsCategoryName property.
        /// </summary>
        public const string DefaultSettingsCategoryName = "ErrorLogger";

        // Delegates

        // Events

        // Fields
        private bool m_autoRegister;
        private bool m_exitOnUnhandledException;
        private bool m_logToUI;
        private bool m_logToFile;
        private bool m_logToEmail;
        private bool m_logToEventLog;
        private bool m_logToScreenshot;
        private string m_smtpServer;
        private string m_contactName;
        private string m_contactEmail;
        private string m_contactPhone;
        private bool m_persistSettings;
        private string m_settingsCategoryName;
        private Assembly m_parentAssembly;
        private Func<string> m_errorTextMethod;
        private Func<string> m_scopeTextMethod;
        private Func<string> m_actionTextMethod;
        private Func<string> m_moreInfoTextMethod;
        private List<Action<Exception>> m_loggers;

        private bool m_logToFileOK;
        private bool m_logToEmailOK;
        private bool m_logToPhoneOK;
        private bool m_logToEventLogOK;
        private bool m_logToScreenshotOK;
        private Exception m_lastException;
        private ApplicationType m_applicationType;

        private LogFile _logFile;

        #endregion

        #region [ Constructors ]

        #endregion

        #region [ Properties ]

        [Category("Behavior"), DefaultValue(DefaultAutoRegister)]
        public bool AutoRegister
        {
            get
            {
                return m_autoRegister;
            }
            set
            {
                m_autoRegister = value;
            }
        }

        [Category("Behavior"), DefaultValue(DefaultExitOnUnhandledException)]
        public bool ExitOnUnhandledException
        {
            get
            {
                return m_exitOnUnhandledException;
            }
            set
            {
                m_exitOnUnhandledException = value;
            }
        }

        [Category("Logging"), DefaultValue(DefaultLogToUI)]
        public bool LogToUI
        {
            get
            {
                return m_logToUI;
            }
            set
            {
                m_logToUI = value;
            }
        }

        [Category("Logging"), DefaultValue(DefaultLogToFile)]
        public bool LogToFile
        {
            get
            {
                return m_logToFile;
            }
            set
            {
                m_logToFile = value;
            }
        }

        [Category("Logging"), DefaultValue(DefaultLogToEmail)]
        public bool LogToEmail
        {
            get
            {
                return m_logToEmail;
            }
            set
            {
                m_logToEmail = value;
            }
        }

        [Category("Logging"), DefaultValue(DefaultLogToEventLog)]
        public bool LogToEventLog
        {
            get
            {
                return m_logToEventLog;
            }
            set
            {
                m_logToEventLog = value;
            }
        }

        [Category("Logging"), DefaultValue(DefaultLogToScreenshot)]
        public bool LogToScreenshot
        {
            get
            {
                return m_logToScreenshot;
            }
            set
            {
                m_logToScreenshot = value;
            }
        }

        [Category("Settings"), DefaultValue(DefaultSmtpServer)]
        public string SmtpServer
        {
            get
            {
                return m_smtpServer;
            }
            set
            {
                m_smtpServer = value;
            }
        }

        [Category("Settings"), DefaultValue(DefaultContactName)]
        public string ContactName
        {
            get
            {
                return m_contactName;
            }
            set
            {
                m_contactName = value;
            }
        }

        [Category("Settings"), DefaultValue(DefaultContactEmail)]
        public string ContactEmail
        {
            get
            {
                return m_contactEmail;
            }
            set
            {
                m_contactEmail = value;
            }
        }

        [Category("Settings"), DefaultValue(DefaultContactPhone)]
        public string ContactPhone
        {
            get
            {
                return m_contactPhone;
            }
            set
            {
                m_contactPhone = value;
            }
        }

        [Category("Persistance"), DefaultValue(DefaultPersistSettings)]
        public bool PersistSettings
        {
            get
            {
                return m_persistSettings;
            }
            set
            {
                m_persistSettings = value;
            }
        }

        [Category("Persistance"), DefaultValue(DefaultSettingsCategoryName)]
        public string SettingsCategoryName
        {
            get
            {
                return m_settingsCategoryName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    m_settingsCategoryName = value;
                }
                else
                {
                    throw (new ArgumentNullException("SettingsCategoryName"));
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Assembly ParentAssembly
        {
            get
            {
                return m_parentAssembly;
            }
            set
            {
                m_parentAssembly = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Func<string> ErrorTextMethod
        {
            get
            {
                return m_errorTextMethod;
            }
            set
            {
                m_errorTextMethod = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Func<string> ScopeTextMethod
        {
            get
            {
                return m_scopeTextMethod;
            }
            set
            {
                m_scopeTextMethod = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Func<string> ActionTextMethod
        {
            get
            {
                return m_actionTextMethod;
            }
            set
            {
                m_actionTextMethod = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Func<string> MoreInfoTextMethod
        {
            get
            {
                return m_moreInfoTextMethod;
            }
            set
            {
                m_moreInfoTextMethod = value;
            }
        }

        [Browsable(false)]
        public string ApplicationName
        {
            get
            {
                switch (ApplicationType)
                {
                    case TVA.ApplicationType.WindowsCui:
                    case TVA.ApplicationType.WindowsGui:
                        return FilePath.NoFileExtension(AppDomain.CurrentDomain.FriendlyName);
                    case TVA.ApplicationType.Web:
                        return HttpContext.Current.Request.ApplicationPath.Replace("/", "");
                    default:
                        return "";
                }
            }
        }

        [Browsable(false)]
        public ApplicationType ApplicationType
        {
            get
            {
                if (m_applicationType == TVA.ApplicationType.Unknown)
                {
                    m_applicationType = TVA.Common.GetApplicationType();
                }
                return m_applicationType;
            }
        }

        [Browsable(false)]
        public LogFile LogFile
        {
            get
            {
                return _logFile;
            }
        }

        [Browsable(false)]
        public Exception LastException
        {
            get
            {
                return m_lastException;
            }
        }

        [Browsable(false)]
        public List<LoggerMethodSignature> Loggers
        {
            get
            {
                return m_loggers;
            }
        }

        private string LogFileName
        {
            get
            {
                return FilePath.AbsolutePath(ApplicationName + ".ExceptionLog.txt");
            }
        }

        private string ScreenshotFileName
        {
            get
            {
                return FilePath.AbsolutePath(ApplicationName + ".ExceptionScreenshot.png");
            }
        }

        #endregion

        #region [ Methods ]

        public void Register()
        {

            if (!Debugger.IsAttached)
            {
                // For winform applications.
                System.Windows.Forms.Application.ThreadException += UnhandledThreadException;

                // For console applications.
                System.AppDomain.CurrentDomain.UnhandledException += UnhandledException;
            }

        }

        public void Unregister()
        {

            if (!Debugger.IsAttached)
            {
                System.Windows.Forms.Application.ThreadException -= UnhandledThreadException;
                System.AppDomain.CurrentDomain.UnhandledException -= UnhandledException;
            }

        }

        public void Log(Exception ex)
        {

            Log(ex, false);

        }

        public void Log(Exception ex, bool exitApplication)
        {

            HandleException(ex, exitApplication);

        }

        public void LoadSettings()
        {

            try
            {
                if (m_persistSettings)
                {
                    ConfigurationFile config = ConfigurationFile.Current;
                    CategorizedSettingsElementCollection settings = config.Settings[m_settingsCategoryName];

                    AutoRegister = settings["AutoRegister"].ValueAs(m_autoRegister);
                    LogToUI = settings["LogToUI"].ValueAs(m_logToUI);
                    LogToFile = settings["LogToFile"].ValueAs(m_logToFile);
                    LogToEmail = settings["LogToEmail"].ValueAs(m_logToEmail);
                    LogToEventLog = settings["LogToEventLog"].ValueAs(m_logToEventLog);
                    LogToScreenshot = settings["LogToScreenshot"].ValueAs(m_logToScreenshot);
                    SmtpServer = settings["SmtpServer"].ValueAs(m_smtpServer);
                    ContactEmail = settings["ContactEmail"].ValueAs(m_contactEmail);
                    ContactName = settings["ContactName"].ValueAs(m_contactName);
                    ContactPhone = settings["ContactPhone"].ValueAs(m_contactPhone);
                    ExitOnUnhandledException = settings["ExitOnUnhandledException"].ValueAs(m_exitOnUnhandledException);
                }
            }
            catch
            {
                // We'll encounter exceptions if the settings are not present in the config file.
            }

        }

        public void SaveSettings()
        {

            if (m_persistSettings)
            {
                try
                {
                    ConfigurationFile config = ConfigurationFile.Current;
                    CategorizedSettingsElementCollection settings = config.Settings[m_settingsCategoryName];

                    settings.Clear();
                    settings["AutoRegister", true].Update(m_autoRegister, "True if the logger is to be automatically registered for handling unhandled exceptions after initialization is complete; otherwise False.");
                    settings["LogToUI", true].Update(m_logToUI, "True if an encountered exception is to be logged to the User Interface; otherwise False.");
                    settings["LogToFile", true].Update(m_logToFile, "True if an encountered exception is to be logged to a file; otherwise False.");
                    settings["LogToEmail", true].Update(m_logToEmail, "True if an email is to be sent to ContactEmail with the details of an encountered exception; otherwise False.");
                    settings["LogToEventLog", true].Update(m_logToEventLog, "True if an encountered exception is to be logged to the Event Log; otherwise False.");
                    settings["LogToScreenshot", true].Update(m_logToScreenshot, "True if a screenshot is to be taken when an exception is encountered; otherwise False.");
                    settings["SmtpServer", true].Update(m_smtpServer, "Name of the SMTP server to be used for sending the email message.");
                    settings["ContactName", true].Update(m_contactName, "Name of the person that the end-user can contact when an exception is encountered.");
                    settings["ContactEmail", true].Update(m_contactEmail, "Comma-seperated list of recipient email addresses for the email message.");
                    settings["ContactPhone", true].Update(m_contactPhone, "Phone number of the person that the end-user can contact when an exception is encountered.");
                    settings["ExitOnUnhandledException", true].Update(m_exitOnUnhandledException, "True if the application must exit when an unhandled exception is encountered; otherwise False.");
                    config.Save();
                }
                catch
                {
                    // We might encounter an exception if for some reason the settings cannot be saved to the config file.
                }
            }

        }

        public void BeginInit()
        {

        }

        public void EndInit()
        {

            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                LoadSettings(); // Load settings from the config file.
                if (m_autoRegister)
                {
                    Register(); // Start the logger automatically if specified.
                }
                m_parentAssembly = System.Reflection.Assembly.GetCallingAssembly();
            }

        }

        private void HandleException(Exception ex, bool exitApplication)
        {

            m_lastException = ex;

            try
            {
                if (!m_loggers.Contains(ExceptionToScreenshot))
                {
                    m_loggers.Add(ExceptionToScreenshot);
                }
                if (!m_loggers.Contains(ExceptionToEventLog))
                {
                    m_loggers.Add(ExceptionToEventLog);
                }
                if (!m_loggers.Contains(ExceptionToEmail))
                {
                    m_loggers.Add(ExceptionToEmail);
                }
                if (!m_loggers.Contains(ExceptionToFile))
                {
                    m_loggers.Add(ExceptionToFile);
                }
                if (!m_loggers.Contains(ExceptionToUI))
                {
                    m_loggers.Add(ExceptionToUI);
                }
            }
            catch
            {

            }

            foreach (Action<Exception> logger in m_loggers)
            {
                try
                {
                    logger.Invoke(ex);
                }
                catch
                {

                }
            }

            if (exitApplication && (ApplicationType == TVA.ApplicationType.WindowsCui || ApplicationType == TVA.ApplicationType.WindowsGui))
            {
                Application.Exit();
                Process.GetCurrentProcess().Kill();
            }

        }

        private void ExceptionToUI(Exception exception)
        {

            if (m_logToUI)
            {
                try
                {
                    switch (ApplicationType)
                    {
                        case TVA.ApplicationType.WindowsCui:
                            ExceptionToWindowsCui();
                            break;
                        case TVA.ApplicationType.WindowsGui:
                            ExceptionToWindowsGui();
                            break;
                        case TVA.ApplicationType.Web:
                            ExceptionToWebPage();
                            break;
                    }
                }
                catch
                {

                }
            }

        }

        private void ExceptionToWindowsGui()
        {

            GelDialog dialog = new GelDialog();
            dialog.Text = string.Format(dialog.Text, ApplicationName, null);
            dialog.PictureBoxIcon.Image = System.Drawing.SystemIcons.Error.ToBitmap();
            dialog.RichTextBoxError.Text = m_errorTextMethod();
            dialog.RichTextBoxScope.Text = m_scopeTextMethod();
            dialog.RichTextBoxAction.Text = m_actionTextMethod();
            dialog.RichTextBoxMoreInfo.Text = m_moreInfoTextMethod();

            dialog.ShowDialog();

        }

        private void ExceptionToWindowsCui()
        {

            StringBuilder message = new StringBuilder();
            message.AppendFormat("{0} has encountered a problem", ApplicationName);
            message.AppendLine();
            message.AppendLine();
            message.Append("What happened:");
            message.AppendLine();
            message.Append(m_errorTextMethod);
            message.AppendLine();
            message.AppendLine();
            message.Append("How this will affect you:");
            message.AppendLine();
            message.Append(m_scopeTextMethod);
            message.AppendLine();
            message.AppendLine();
            message.Append("What you can do about it:");
            message.AppendLine();
            message.Append(m_actionTextMethod);
            message.AppendLine();
            message.AppendLine();
            message.Append("More information:");
            message.AppendLine();
            message.Append(m_moreInfoTextMethod);
            message.AppendLine();

            System.Console.Write(message.ToString());

        }

        private void ExceptionToWebPage()
        {

            StringBuilder html = new StringBuilder();
            html.Append("<HTML>");
            html.AppendLine();
            html.Append("<HEAD>");
            html.AppendLine();
            html.Append("<TITLE>");
            html.AppendLine();
            html.AppendFormat("{0} has encountered a problem", ApplicationName);
            html.AppendLine();
            html.Append("</TITLE>");
            html.AppendLine();
            html.Append("<STYLE>");
            html.AppendLine();
            html.Append("body {font-family:\"Verdana\";font-weight:normal;font-size: .7em;color:black; background-color:white;}");
            html.AppendLine();
            html.Append("b {font-family:\"Verdana\";font-weight:bold;color:black;margin-top: -5px}");
            html.AppendLine();
            html.Append("H1 { font-family:\"Verdana\";font-weight:normal;font-size:18pt;color:red }");
            html.AppendLine();
            html.Append("H2 { font-family:\"Verdana\";font-weight:normal;font-size:14pt;color:maroon }");
            html.AppendLine();
            html.Append("pre {font-family:\"Lucida Console\";font-size: .9em}");
            html.AppendLine();
            html.Append("</STYLE>");
            html.AppendLine();
            html.Append("</HEAD>");
            html.AppendLine();
            html.Append("<BODY>");
            html.AppendLine();
            html.Append("<H1>");
            html.AppendLine();
            html.AppendFormat("The {0} website has encountered a problem", ApplicationName);
            html.AppendLine();
            html.Append("<hr width=100% size=1 color=silver></H1>");
            html.AppendLine();
            html.Append("<H2>What Happened</H2>");
            html.AppendLine();
            html.Append("<BLOCKQUOTE>");
            html.AppendLine();
            html.Append(m_errorTextMethod);
            html.AppendLine();
            html.Append("</BLOCKQUOTE>");
            html.AppendLine();
            html.Append("<H2>How this will affect you</H2>");
            html.AppendLine();
            html.Append("<BLOCKQUOTE>");
            html.AppendLine();
            html.Append(m_scopeTextMethod);
            html.AppendLine();
            html.Append("</BLOCKQUOTE>");
            html.AppendLine();
            html.Append("<H2>What you can do about it</H2>");
            html.AppendLine();
            html.Append("<BLOCKQUOTE>");
            html.AppendLine();
            html.Append(m_actionTextMethod);
            html.AppendLine();
            html.Append("</BLOCKQUOTE>");
            html.AppendLine();
            html.Append("<INPUT type=button value=\"More Information &gt;&gt;\" onclick=\"this.style.display=\'none\'; document.getElementById(\'MoreInfo\').style.display=\'block\'\">");
            html.AppendLine();
            html.Append("<DIV style=\'display:none;\' id=\'MoreInfo\'>");
            html.AppendLine();
            html.Append("<H2>More information</H2>");
            html.AppendLine();
            html.Append("<TABLE width=\"100%\" bgcolor=\"#ffffcc\">");
            html.AppendLine();
            html.Append("<TR><TD>");
            html.AppendLine();
            html.Append("<CODE><PRE>");
            html.AppendLine();
            html.Append(m_moreInfoTextMethod);
            html.AppendLine();
            html.Append("</PRE></CODE>");
            html.AppendLine();
            html.Append("<TD><TR>");
            html.AppendLine();
            html.Append("</DIV>");
            html.AppendLine();
            html.Append("</BODY>");
            html.AppendLine();
            html.Append("</HTML>");
            html.AppendLine();

            HttpContext.Current.Response.Write(html.ToString());
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
            HttpContext.Current.Server.ClearError();

        }

        private void ExceptionToFile(Exception exception)
        {

            if (m_logToFile)
            {
                try
                {
                    m_logToFileOK = false;

                    _logFile.Name = LogFileName;
                    if (!_logFile.IsOpen)
                    {
                        _logFile.Open();
                    }
                    _logFile.WriteTimestampedLine(ExceptionToString(exception, m_parentAssembly));

                    m_logToFileOK = true;
                }
                catch
                {

                }
                finally
                {
                    _logFile.Close();
                }
            }

        }

        private void ExceptionToEmail(Exception exception)
        {

            if (m_logToEmail && !string.IsNullOrEmpty(m_contactEmail))
            {
                try
                {
                    m_logToEmailOK = false;

                    Mail email = new Mail();
                    email.From = string.Format("{0}@tva.gov", Environment.MachineName);
                    email.Recipients = m_contactEmail;
                    email.Subject = string.Format("Exception in {0} at {1}", ApplicationName, DateTime.Now.ToString());
                    email.Body = ExceptionToString(exception, m_parentAssembly);
                    email.Attachments = FilePath.AbsolutePath(ScreenshotFileName);
                    email.SmtpServer = m_smtpServer;
                    email.Send();

                    m_logToEmailOK = true;
                }
                catch
                {

                }
            }

        }

        private void ExceptionToEventLog(Exception exception)
        {

            if (m_logToEventLog)
            {
                try
                {
                    m_logToEventLogOK = false;

                    // Write the formatted exception message to the event log.
                    EventLog.WriteEntry(ApplicationName, ExceptionToString(exception, m_parentAssembly), EventLogEntryType.Error);

                    m_logToEventLogOK = true;
                }
                catch
                {

                }
            }

        }

        private void ExceptionToScreenshot(Exception exception)
        {

            if (m_logToScreenshot && (ApplicationType == ApplicationType.WindowsCui || ApplicationType == ApplicationType.WindowsGui))
            {
                try
                {
                    m_logToScreenshotOK = false;

                    Size fullScreen = new Size(0, 0);
                    foreach (Screen myScreen in Screen.AllScreens)
                    {
                        if (fullScreen.IsEmpty)
                        {
                            fullScreen = myScreen.Bounds.Size;
                        }
                        else
                        {
                            if (myScreen.Bounds.Location.X > 0)
                            {
                                fullScreen.Width += myScreen.Bounds.Width;
                            }
                            if (myScreen.Bounds.Location.Y > 0)
                            {
                                fullScreen.Height += myScreen.Bounds.Height;
                            }
                        }
                    }

                    using (Bitmap screenshot = TVA.Drawing.Image.CaptureScreenshot(fullScreen, System.Drawing.Imaging.ImageFormat.Png))
                    {
                        screenshot.Save(ScreenshotFileName);
                    }


                    m_logToScreenshotOK = true;
                }
                catch
                {

                }
            }

        }

        private string GetErrorText()
        {

            StringBuilder errorText = new StringBuilder();
            errorText.AppendFormat("An unexpected exception has occurred in {0}. ", ApplicationName);
            errorText.Append("This may be due to an inconsistent system state or a programming error.");

            return errorText.ToString();

        }

        private string GetScopeText()
        {

            StringBuilder scopeText = new StringBuilder();
            switch (ApplicationType)
            {
                case TVA.ApplicationType.WindowsCui:
                case TVA.ApplicationType.WindowsGui:
                    scopeText.Append("The action you requested was not performed.");
                    break;
                case TVA.ApplicationType.Web:
                    scopeText.Append("The current page will not load.");
                    break;
            }

            return scopeText.ToString();

        }

        private string GetActionText()
        {

            StringBuilder actionText = new StringBuilder();
            switch (ApplicationType)
            {
                case TVA.ApplicationType.WindowsCui:
                case TVA.ApplicationType.WindowsGui:
                    actionText.AppendFormat("Restart {0}, and try repeating your last action. ", ApplicationName);
                    break;
                case TVA.ApplicationType.Web:
                    actionText.AppendFormat("Close your browser, navigate back to the {0} website, and try repeating you last action. ", ApplicationName);
                    break;
            }
            actionText.Append("Try alternative methods of performing the same action. ");
            if (!string.IsNullOrEmpty(m_contactName) && (!string.IsNullOrEmpty(m_contactPhone) || !string.IsNullOrEmpty(m_contactPhone)))
            {
                actionText.AppendFormat("If you need immediate assistance, contact {0} ", m_contactName);
                if (!string.IsNullOrEmpty(m_contactEmail))
                {
                    actionText.AppendFormat("via email at {0}", m_contactEmail);
                    if (!string.IsNullOrEmpty(m_contactPhone))
                    {
                        actionText.Append(" or ");
                    }
                }
                if (!string.IsNullOrEmpty(m_contactPhone))
                {
                    actionText.AppendFormat("via phone at {0}", m_contactPhone);
                }
                actionText.Append(".");
            }

            return actionText.ToString();

        }

        private string GetMoreInfoText()
        {

            string bullet;
            switch (ApplicationType)
            {
                case TVA.ApplicationType.WindowsCui:
                    bullet = "-";
                    break;
                case TVA.ApplicationType.Web:
                case TVA.ApplicationType.WindowsGui:
                    bullet = "•";
                    break;
            }

            StringBuilder moreInfoText = new StringBuilder();
            moreInfoText.Append("The following information about the error was automatically captured:");
            moreInfoText.AppendLine();
            moreInfoText.AppendLine();
            if (m_logToScreenshot)
            {
                moreInfoText.AppendFormat(" {0} ", bullet);
                if (m_logToScreenshotOK)
                {
                    moreInfoText.Append("a screenshot was taken of the desktop at:");
                    moreInfoText.AppendLine();
                    moreInfoText.Append("   ");
                    moreInfoText.Append(ScreenshotFileName);
                }
                else
                {
                    moreInfoText.Append("a screenshot could NOT be taken of the desktop.");
                }
                moreInfoText.AppendLine();
            }
            if (m_logToEventLog)
            {
                moreInfoText.AppendFormat(" {0} ", bullet);
                if (m_logToEventLogOK)
                {
                    moreInfoText.Append("an event was written to the application log");
                }
                else
                {
                    moreInfoText.Append("an event could NOT be written to the application log");
                }
                moreInfoText.AppendLine();
            }
            if (m_logToFile)
            {
                moreInfoText.AppendFormat(" {0} ", bullet);
                if (m_logToFileOK)
                {
                    moreInfoText.Append("details were written to a text log at:");
                }
                else
                {
                    moreInfoText.Append("details could NOT be written to the text log at:");
                }
                moreInfoText.AppendLine();
                moreInfoText.Append("   ");
                moreInfoText.Append(LogFileName);
                moreInfoText.AppendLine();
            }
            if (m_logToEmail)
            {
                moreInfoText.AppendFormat(" {0} ", bullet);
                if (m_logToEmailOK)
                {
                    moreInfoText.Append("an email has been sent to:");
                }
                else
                {
                    moreInfoText.Append("an email could NOT be sent to:");
                }
                moreInfoText.AppendLine();
                moreInfoText.Append("   ");
                moreInfoText.Append(m_contactEmail);
                moreInfoText.AppendLine();
            }
            moreInfoText.AppendLine();
            moreInfoText.AppendLine();
            moreInfoText.Append("Detailed error information follows:");
            moreInfoText.AppendLine();
            moreInfoText.AppendLine();
            moreInfoText.Append(ExceptionToString(m_lastException, m_parentAssembly));

            return moreInfoText.ToString();

        }

        private void UnhandledThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {

            HandleException(e.Exception, m_exitOnUnhandledException);

        }

        private void UnhandledException(object sender, System.UnhandledExceptionEventArgs e)
        {

            HandleException(((Exception)e.ExceptionObject), m_exitOnUnhandledException);

        }

        #endregion

        #region [ Static ]

        public static string ExceptionToString(Exception ex)
        {

            Assembly parentAssembly;
            switch (TVA.Common.GetApplicationType())
            {
                case TVA.ApplicationType.WindowsCui:
                case ApplicationType.WindowsGui:
                    parentAssembly = System.Reflection.Assembly.GetEntryAssembly();
                    break;
                case ApplicationType.Web:
                    parentAssembly = System.Reflection.Assembly.GetCallingAssembly();
                    break;
            }

            return ExceptionToString(ex, parentAssembly);

        }

        public static string SystemInfo()
        {

            StringBuilder info = new StringBuilder();
            info.AppendFormat("Date and Time:         {0}", DateTime.Now);
            info.AppendLine();
            switch (TVA.Common.GetApplicationType())
            {
                case ApplicationType.WindowsCui:
                case ApplicationType.WindowsGui:
                    UserInfo currentUserInfo = new UserInfo(Thread.CurrentPrincipal.Identity.Name);
                    info.AppendFormat("Machine Name:          {0}", Environment.MachineName);
                    info.AppendLine();
                    info.AppendFormat("Machine IP:            {0}", Dns.GetHostEntry(Environment.MachineName).AddressList[0].ToString());
                    info.AppendLine();
                    info.AppendFormat("Current User ID:       {0}", currentUserInfo.LoginID);
                    info.AppendLine();
                    info.AppendFormat("Current User Name:     {0}", currentUserInfo.FullName);
                    info.AppendLine();
                    info.AppendFormat("Current User Phone:    {0}", currentUserInfo.Telephone);
                    info.AppendLine();
                    info.AppendFormat("Current User Email:    {0}", currentUserInfo.Email);
                    info.AppendLine();
                    break;
                case ApplicationType.Web:
                    UserInfo remoteUserInfo = new UserInfo(Thread.CurrentPrincipal.Identity.Name, true);
                    info.AppendFormat("Server Name:           {0}", Environment.MachineName);
                    info.AppendLine();
                    info.AppendFormat("Server IP:             {0}", Dns.GetHostEntry(Environment.MachineName).AddressList[0].ToString());
                    info.AppendLine();
                    info.AppendFormat("Process User:          {0}", System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                    info.AppendLine();
                    info.AppendFormat("Remote User ID:        {0}", remoteUserInfo.LoginID);
                    info.AppendLine();
                    info.AppendFormat("Remote User Name:      {0}", remoteUserInfo.FullName);
                    info.AppendLine();
                    info.AppendFormat("Remote User Phone:     {0}", remoteUserInfo.Telephone);
                    info.AppendLine();
                    info.AppendFormat("Remote User Email:     {0}", remoteUserInfo.Email);
                    info.AppendLine();
                    info.AppendFormat("Remote Host:           {0}", HttpContext.Current.Request.ServerVariables["REMOTE_HOST"]);
                    info.AppendLine();
                    info.AppendFormat("Remote Address:        {0}", HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
                    info.AppendLine();
                    info.AppendFormat("HTTP Agent:            {0}", HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"]);
                    info.AppendLine();
                    info.AppendFormat("HTTP Referer:          {0}", HttpContext.Current.Request.ServerVariables["HTTP_REFERER"]);
                    info.AppendLine();
                    info.AppendFormat("Web Page URL:          {0}", HttpContext.Current.Request.Url.ToString());
                    info.AppendLine();
                    break;
            }

            return info.ToString();

        }

        public static string ApplicationInfo()
        {

            System.Reflection.Assembly parentAssembly;
            switch (TVA.Common.GetApplicationType())
            {
                case TVA.ApplicationType.WindowsCui:
                case ApplicationType.WindowsGui:
                    // For a windows application the entry assembly will be the executable.
                    parentAssembly = System.Reflection.Assembly.GetEntryAssembly();
                    break;
                case ApplicationType.Web:
                    // For a web site in .Net 2.0 we don't have an entry assembly. However, at this point the
                    // calling assembly will be consumer of this function (i.e. one of the web site DLLs).
                    // See: http://msdn.microsoft.com/msdnmag/issues/06/01/ExtremeASPNET/
                    parentAssembly = System.Reflection.Assembly.GetCallingAssembly();
                    break;
            }

            return ApplicationInfo(parentAssembly);

        }

        public static string ExceptionGeneralInfo(Exception ex)
        {

            StringBuilder info = new StringBuilder();
            info.AppendFormat("Exception Source:      {0}", ex.Source);
            info.AppendLine();
            info.AppendFormat("Exception Type:        {0}", ex.GetType().FullName);
            info.AppendLine();
            info.AppendFormat("Exception Message:     {0}", ex.Message);
            info.AppendLine();
            if (ex.TargetSite != null)
            {
                info.AppendFormat("Exception Target Site: {0}", ex.TargetSite.Name);
                info.AppendLine();
            }

            return info.ToString();

        }

        public static string ExceptionStackTrace(Exception ex)
        {

            StringBuilder trace = new StringBuilder();
            StackTrace stack = new StackTrace(ex, true);
            for (int i = 0; i <= stack.FrameCount - 1; i++)
            {
                StackFrame stackFrame = stack.GetFrame(i);
                MemberInfo method = stackFrame.GetMethod();
                string codeFileName = stackFrame.GetFileName();

                // build method name
                trace.AppendFormat("   {0}.{1}.{2}", method.DeclaringType.Namespace, method.DeclaringType.Name, method.Name);

                // build method params
                trace.Append("(");
                int parameterCount = 0;
                foreach (ParameterInfo parameter in stackFrame.GetMethod().GetParameters())
                {
                    parameterCount++;
                    if (parameterCount > 1)
                    {
                        trace.Append(", ");
                    }
                    trace.AppendFormat("{0} As {1}", parameter.Name, parameter.ParameterType.Name);
                }
                trace.Append(")");
                trace.AppendLine();

                // if source code is available, append location info
                trace.Append("       ");

                if (!string.IsNullOrEmpty(codeFileName))
                {
                    trace.Append(System.IO.Path.GetFileName(codeFileName));
                    trace.AppendFormat(": Ln {0:#0000}", stackFrame.GetFileLineNumber());
                    trace.AppendFormat(", Col {0:#00}", stackFrame.GetFileColumnNumber());
                    // if IL is available, append IL location info
                    if (stackFrame.GetILOffset() != StackFrame.OFFSET_UNKNOWN)
                    {
                        trace.AppendFormat(", IL {0:#0000}", stackFrame.GetILOffset());
                    }
                }
                else
                {
                    ApplicationType appType = TVA.Common.GetApplicationType();
                    if (appType == ApplicationType.WindowsCui || appType == TVA.ApplicationType.WindowsGui)
                    {
                        trace.Append(System.IO.Path.GetFileName(Assembly.GetEntryAssembly().CodeBase));
                    }
                    else
                    {
                        trace.Append("(unknown file)");
                    }
                    // native code offset is always available
                    trace.AppendFormat(": N {0:#00000}", stackFrame.GetNativeOffset());
                }
                trace.AppendLine();
            }

            return trace.ToString();

        }

        private static string ExceptionToString(Exception ex, System.Reflection.Assembly parentAssembly)
        {

            System.Text.StringBuilder with_1 = new StringBuilder();
            if (ex.InnerException != null)
            {
                // sometimes the original exception is wrapped in a more relevant outer exception
                // the detail exception is the "inner" exception
                // see http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnbda/html/exceptdotnet.asp
                with_1.Append("(Inner Exception)");
                with_1.AppendLine();
                with_1.Append(ExceptionToString(ex.InnerException));
                with_1.AppendLine();
                with_1.Append("(Outer Exception)");
                with_1.AppendLine();
            }

            // Get general system information.
            with_1.Append(SystemInfo());
            with_1.AppendLine();
            // Get general application information.
            with_1.Append(ApplicationInfo(parentAssembly));
            with_1.AppendLine();
            // Get general exception information.
            with_1.Append(ExceptionGeneralInfo(ex));
            with_1.AppendLine();
            // Get the stack trace for the exception.
            with_1.Append("---- Stack Trace ----");
            with_1.AppendLine();
            with_1.Append(ExceptionStackTrace(ex));
            with_1.AppendLine();

            return with_1.ToString();

        }

        private static string ApplicationInfo(System.Reflection.Assembly parentAssembly)
        {

            System.Text.StringBuilder with_1 = new StringBuilder();
            AssemblyInformation parentAssemblyInfo = new AssemblyInformation(parentAssembly);
            with_1.AppendFormat("Application Domain:    {0}", AppDomain.CurrentDomain.FriendlyName);
            with_1.AppendLine();
            with_1.AppendFormat("Assembly Codebase:     {0}", parentAssemblyInfo.CodeBase);
            with_1.AppendLine();
            with_1.AppendFormat("Assembly Full Name:    {0}", parentAssemblyInfo.FullName);
            with_1.AppendLine();
            with_1.AppendFormat("Assembly Version:      {0}", parentAssemblyInfo.Version.ToString());
            with_1.AppendLine();
            with_1.AppendFormat("Assembly Build Date:   {0}", parentAssemblyInfo.BuildDate.ToString());
            with_1.AppendLine();
            with_1.AppendFormat(".Net Runtime Version:  {0}", Environment.Version.ToString());
            with_1.AppendLine();

            return with_1.ToString();

        }

        #endregion

    }
}
