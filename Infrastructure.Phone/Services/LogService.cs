using Infrastructure.Common.Contracts;
using Infrastructure.Phone.Contracts;
using System;

namespace Infrastructure.Phone.Services
{
    public class LogService : ILogService
    {
        IUserStorageService userStorageService;

        public LogService(IUserStorageService userStorageService)
        {
            this.userStorageService = userStorageService;
        }

        public void WriteError(string source, Exception exception)
        {
            WriteLog(source, exception.ToString(), "Error");
        }

        public void WriteError(string source, string message)
        {
            WriteLog(source, message, "Error");
        }

        public void WriteWarning(string source, string message)
        {
            WriteLog(source, message, "Warning");
        }

        public void WriteInfo(string source, string message)
        {
            WriteLog(source, message, "Info");
        }

        public void WriteLog(string source, string message, string messageType)
        {
            try
            {
                string logMessage = String.Format("{0} {1}\r\n{2}: {3}\r\n", DateTime.Now.ToString("yy/MM/dd HH:mm:ss"), messageType, source, message);
                userStorageService.WriteLineToFile("AppLogs.txt", logMessage);
            }
            catch { /* Avoid any exception at this point. */ }
        }

        public void Clear()
        {
            try
            {
                userStorageService.Delete("AppLogs.txt");
            }
            catch { /* Avoid any exception at this point. */ }
        }
    }
 
    
}