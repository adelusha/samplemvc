using System;
using log4net;

namespace Logging
    {
    public class NSLogger: ILogging.ILogger {

        private readonly ILog _logger;

        public NSLogger()
        {
        _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void Debug(string message)
        {
           _logger.Debug(message);
        }

        public void Debug(Exception exception)
        {
            _logger.Debug(exception);
        }

        public void Debug(Exception exception, string message)
        {
            _logger.Debug(message, exception);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Info(Exception exception)
        {
            _logger.Info(exception);
        }

        public void Info(Exception exception, string message)
        {
            _logger.Info(message, exception);
        }

        public void Warn(string message)
        {
           _logger.Warn(message);
        }

        public void Warn(Exception exception)
        {
            _logger.Warn(exception);
        }

        public void Warn(Exception exception, string message)
        {
            _logger.Warn(message, exception);
        }

        public void Error(string message)
        {
           _logger.Error(message);
        }

        public void Error(Exception exception)
        {
            _logger.Error(exception);
        }

        public void Error(Exception exception, string message)
        {
           _logger.Error(message, exception);
        }

        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }

        public void Fatal(Exception exception)
        {
           _logger.Fatal(exception);
        }

        public void Fatal(Exception exception, string message)
        {
            _logger.Fatal(message, exception);
        }
    }
    }
