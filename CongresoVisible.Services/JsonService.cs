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
using System.Collections.Generic;

namespace CongresoVisible.Services
{
    public class JsonService : ServiceBase, IJsonService
    {
        ISettingsService settingsService;

        public async Task<TData> GetDataAsync<TData>(string serviceUrlKey)
        {
            var client = new HttpClient();
            var serviceUrl = settingsService.GetSettingsValue(serviceUrlKey);
            var json = await client.GetStringAsync(serviceUrl);

            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(TData));
                return (TData)serializer.ReadObject(stream);
            }
        }

        public async Task<PeopleContainer> GetPeopleAsync(string filter)
        {
            var client = new HttpClient();
            settingsService = GetService<ISettingsService>();

            var serviceUrl = settingsService.GetSettingsValue("PeopleServiceUrl");
            var json = await client.GetStringAsync(serviceUrl);

            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(PeopleContainer));
                return serializer.ReadObject(stream) as PeopleContainer;
            }
        }

        public async Task<Person> GetPersonAsync(int id)
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

        public async Task<PartiesContainer> GetPartiesAsync()
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

        public FiltersContainer GetFilters()
        {
            return new FiltersContainer()
            {
                filters = 
                {
                    new Filter() { key = "partido_politico", name = settingsService.GetSettingsValue("DisplayNamePartyFilter") },
                    new Filter() { key = "genero", name = settingsService.GetSettingsValue("DisplayNameGenderFilter") },
                    new Filter() { key = "ha_sido_congresista", name = settingsService.GetSettingsValue("DisplayNameWasCongressmanFilter") },
                    new Filter() { key = "camara", name = settingsService.GetSettingsValue("DisplayNameCamaraFilter") },
                }
            };
        }

        public async Task<PeopleContainer> GetPeopleByPartyAsync(int party)
        {
            var client = new HttpClient();
            settingsService = GetService<ISettingsService>();

            var serviceUrl = settingsService.GetSettingsValue("PeopleServiceUrl") + "&partido_politico=" + party;
            var json = await client.GetStringAsync(serviceUrl);

            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(PeopleContainer));
                return serializer.ReadObject(stream) as PeopleContainer;
            }
        }
    }
}
