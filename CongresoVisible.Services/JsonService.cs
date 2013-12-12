using CongresoVisible.Contracts.Services;
using CongresoVisible.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Common;
using CongresoVisible.Contracts.ViewModels;
using System.Collections.ObjectModel;

namespace CongresoVisible.Services
{
    public class JsonService : ServiceBase, IJsonService
    {
        ISettingsService settingsService;

        public async Task<PeopleContainer> GetPeople(string filter)
        {
            var client = new HttpClient();
            settingsService = GetService<ISettingsService>();

            var serviceUrl = "http://congresovisible.org/api/apis/partidos/?format=json";
            var json = await client.GetStringAsync(serviceUrl);

            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(PeopleContainer));
                return serializer.ReadObject(stream) as PeopleContainer;
            }
        }

        public async Task<Person> GetPerson(int id)
        {
            var client = new HttpClient();
            settingsService = GetService<ISettingsService>();

            var serviceUrl = settingsService.GetSettingsValue("PersonServiceUrl");
            var json = await client.GetStringAsync(serviceUrl);

            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Person));
                return serializer.ReadObject(stream) as Person;
            }
        }

        public async Task<PartiesContainer> GetParties()
        {
            var client = new HttpClient();
            settingsService = GetService<ISettingsService>();

            var serviceUrl = settingsService.GetSettingsValue("PartiesServiceUrl");
            var json = await client.GetStringAsync(serviceUrl);
            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(PartiesContainer));
                return serializer.ReadObject(stream) as PartiesContainer;
            }
        }

        public Task<FiltersContainer> GetFilters()
        {
            throw new NotImplementedException();
        }
    }
}
