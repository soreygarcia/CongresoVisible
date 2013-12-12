using CongresoVisible.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.FakeServices
{
    public class FakeSettingsService : ISettingsService
    {
        public Action Callback { get; set; }

        public string GetSettingsValue(string key)
        {
            Callback();
            return string.Empty;
        }

        public object GetStateValue(string key)
        {
            Callback();
            return new object();
        }

        public void SetStateValue(string key, object value)
        {
            Callback();
        }


        public string GetIsolatedSettingsValue(string key)
        {
            Callback();
            return string.Empty;
        }

        public void SetIsolatedSettingsValue(string key, object value)
        {
            Callback();
        }
    }
}
