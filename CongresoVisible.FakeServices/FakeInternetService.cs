using CongresoVisible.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.FakeServices
{
    public class FakeInternetService : IInternetService
    {
        public bool isNetworkAvailable;

        public void SetNetworkAvailability(bool value)
        {
            isNetworkAvailable = value;
        }

        public event EventHandler InternetAvailabilityChanged;

        bool IInternetService.IsNetworkAvailable
        {
            get { return isNetworkAvailable; }
        }
    }
}
