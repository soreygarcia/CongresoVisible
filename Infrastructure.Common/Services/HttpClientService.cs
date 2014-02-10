using Infrastructure.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Services
{
    public class HttpClientService : IHttpClientService
    {
        public async Task<string> GetStringAsync(string serviceUrl)
        {
            using (var client = new HttpClient())
            {
                return await client.GetStringAsync(new Uri(serviceUrl));
            }
        }
    }
}
