using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Contracts.Services
{
    public interface ISettingsService
    {
        string GetSettingsValue(string key);

        string GetIsolatedSettingsValue(string key);
        void SetIsolatedSettingsValue(string key, object value);

        object GetStateValue(string key);
        void SetStateValue(string key, object value);
    }
}
