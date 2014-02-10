using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Contracts
{
    public interface IHttpClientService
    {
        Task<string> GetStringAsync(string serviceUrl);
    } 
}
