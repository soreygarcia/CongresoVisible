using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Contracts.Services
{
    public interface IInternetService
    {
        event EventHandler InternetAvailabilityChanged;
        bool IsNetworkAvailable { get; }

        void Initialize();
    }
}
