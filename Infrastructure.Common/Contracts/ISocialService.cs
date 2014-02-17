using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Contracts
{
    public interface ISocialService
    {
        void ShareLink(string title, string message, Uri url);
        void ShareMessage(string message);        
    }
}
