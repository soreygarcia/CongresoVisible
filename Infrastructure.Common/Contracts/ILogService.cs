using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Common.Contracts
{
    public interface ILogService
    {
        void WriteError(string source, Exception exception);

        void WriteError(string source, string message);

        void WriteWarning(string source, string message);

        void WriteInfo(string source, string message);

        void WriteLog(string source, string message, string messageType);

        void Clear();
    }
}
