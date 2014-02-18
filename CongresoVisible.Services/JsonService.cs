using CongresoVisible.Services.Contracts;
using CongresoVisible.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Common;
using System.Collections.ObjectModel;
using Infrastructure.Common.Contracts;
using Contracts = CongresoVisible.Services.Contracts;

namespace CongresoVisible.Services
{
    public class JsonService : Contracts.IJsonService
    {
        ISettingsService settingsService;
        IHttpClientService httpClientService;

        public JsonService(ISettingsService settingsService, IHttpClientService httpClientService)
        {
            this.settingsService = settingsService;
            this.httpClientService = httpClientService;
        }

        public async Task<Person> GetPersonAsync(int id)
        {
            try
            {
                var serviceUrl = string.Format(settingsService.GetSettingsValue("PersonServiceUrl"), id);
                var json = await httpClientService.GetStringAsync(serviceUrl);

                if (json.Contains("Not found"))
                {
                    return null;
                }
                else
                {
                    using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
                    {
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Person));
                        return serializer.ReadObject(stream) as Person;
                    }
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                
                throw;
            }
        }

        public async Task<PeopleContainer> GetPeopleAsync(string filter)
        {
            var serviceUrl = settingsService.GetSettingsValue("PeopleServiceUrl");
            var json = await httpClientService.GetStringAsync(serviceUrl);

            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(PeopleContainer));
                return serializer.ReadObject(stream) as PeopleContainer;
            }
        }

        public async Task<PartiesContainer> GetPartiesAsync()
        {
            var serviceUrl = settingsService.GetSettingsValue("PartiesServiceUrl");
            var json = await httpClientService.GetStringAsync(serviceUrl);
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
            var serviceUrl = settingsService.GetSettingsValue("PeopleServiceUrl") + "&partido_politico=" + party;
            var json = await httpClientService.GetStringAsync(serviceUrl);

            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(PeopleContainer));
                return serializer.ReadObject(stream) as PeopleContainer;
            }
        }
    }
}
