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
using CongresoVisible.Services.Helpers;
using System.Collections.ObjectModel;

namespace CongresoVisible.Services
{
    public class JsonService : ServiceBase, IJsonService
    {
        ISettingsService settingsService;

        public void GetPeople(string filter)
        {
            var client = new HttpClient();
            settingsService = GetService<ISettingsService>();

            var serviceUrl = settingsService.GetSettingsValue("PeopleServiceUrl");
            var response = client.GetAsync(serviceUrl).Result;
            var json = response.Content.ReadAsStringAsync().Result;

            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(PeopleContainer));
                PeopleContainer result = serializer.ReadObject(stream) as PeopleContainer;

                IMainViewModel context = GetContext<IMainViewModel>();
                ViewModelHelper.SetPeople(context, result);
            }
        }

        public void GetPerson(int id)
        {
            var client = new HttpClient();
            settingsService = GetService<ISettingsService>();

            var serviceUrl = settingsService.GetSettingsValue("PersonServiceUrl");
            var response = client.GetAsync(serviceUrl).Result;
            var json = response.Content.ReadAsStringAsync().Result;
            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Person));
                var result = serializer.ReadObject(stream) as Person;

                IMainViewModel context = GetContext<IMainViewModel>();
                ViewModelHelper.SetSelectedPerson(context, result);
            }
        }

        public void GetParties()
        {
            var client = new HttpClient();
            settingsService = GetService<ISettingsService>();

            var serviceUrl = settingsService.GetSettingsValue("PartiesServiceUrl");
            var response = client.GetAsync(serviceUrl).Result;
            var json = response.Content.ReadAsStringAsync().Result;
            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(PartiesContainer));
                var result = serializer.ReadObject(stream) as PartiesContainer;

                IMainViewModel context = GetContext<IMainViewModel>();
                ViewModelHelper.SetParties(context, result);
            }
        }

        public void GetFilters()
        {
            throw new NotImplementedException();
        }
    }
}
