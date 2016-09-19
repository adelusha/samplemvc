using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILogging
    {
    public interface ILogger
        {
        #region Debug

        /// <summary>
        /// Logs a debug message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void Debug(string message);

        /// <summary>
        /// Logs an exception with a logging level of <see cref="System.Diagnostics.Debug"/>.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        void Debug(Exception exception);

        /// <summary>
        /// Logs an exception and an additional message with a logging level of Debug
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        void Debug(Exception exception, string message);

        #endregion

        #region Info

        /// <summary>
        /// Logs an informational message 
        /// </summary>
        /// <param name="message">The message to log.</param>
        void Info(string message);

        /// <summary>
        /// Logs an exception with a logging level of Info.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        void Info(Exception exception);

        /// <summary>
        /// Logs an exception and an additional message with a logging level of Info
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        void Info(Exception exception, string message);

        #endregion

        #region Warn

        /// <summary>
        /// Logs a warning message 
        /// </summary>
        /// <param name="message">The message to log.</param>
        void Warn(string message);

        /// <summary>
        /// Logs an exception with a logging level of Warn
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        void Warn(Exception exception);

        /// <summary>
        /// Logs an exception and an additional message with a logging level of Warn
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        void Warn(Exception exception, string message);

        #endregion

        #region Error

        /// <summary>
        /// Logs an error message 
        /// </summary>
        /// <param name="message">The message to log.</param>
        void Error(string message);

        /// <summary>
        /// Logs an exception with a logging level of Error
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        void Error(Exception exception);

        /// <summary>
        /// Logs an exception and an additional message with a logging level of
        /// <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        void Error(Exception exception, string message);

        #endregion

        #region Fatal

        /// <summary>
        /// Logs a fatal error message 
        /// </summary>
        /// <param name="message">The message to log.</param>
        void Fatal(string message);

        /// <summary>
        /// Logs an exception with a logging level of Fatal
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        void Fatal(Exception exception);

        /// <summary>
        /// Logs an exception and an additional message with a logging level of Fatal
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        void Fatal(Exception exception, string message);

        #endregion
        }
    }
