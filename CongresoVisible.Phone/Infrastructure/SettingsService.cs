using CongresoVisible.Contracts.Services;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Phone.Infrastructure
{
    public class SettingsService : ISettingsService
    {
        public string GetSettingsValue(string key)
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains(key))
            {
                return IsolatedStorageSettings.ApplicationSettings[key] as string;
            }

            return string.Empty;
        }

        public void SetSettingsValue(string key, object value)
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
    }
}
