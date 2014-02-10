using Infrastructure.Common.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Services
{
    public class JsonService : IJsonService
    {
        public async Task<TData> GetDataAsync<TData>(string serviceUrl)
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync(serviceUrl);

            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(TData));
                return (TData)serializer.ReadObject(stream);
            }
        }
    }
}
