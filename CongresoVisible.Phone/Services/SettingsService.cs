using CongresoVisible.Services.Contracts;
using CongresoVisible.Phone.Resources;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Services
{
    public class SettingsService : ISettingsService
    {
        public string GetIsolatedSettingsValue(string key)
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains(key))
            {
                return IsolatedStorageSettings.ApplicationSettings[key] as string;
            }

            return string.Empty;
        }

        public void SetIsolatedSettingsValue(string key, object value)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains(key))
            {
                settings.Add(key, value);
            }
            else
            {
                settings[key] = value;
            }
            settings.Save();
        }

        public object GetStateValue(string key)
        {
            if (PhoneApplicationService.Current.State.ContainsKey(key))
            {
                return PhoneApplicationService.Current.State[key] as string;
            }

            return null;
        }

        public void SetStateValue(string key, object value)
        {
            PhoneApplicationService.Current.State[key] = value;
        }


        public string GetSettingsValue(string key)
        {
            return AppResources.ResourceManager.GetString(key);
        }
    }
}
