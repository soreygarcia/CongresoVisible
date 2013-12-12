using CongresoVisible.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace CongresoVisible.Phone.Infrastructure
{
    public class InternetService : IInternetService
    {
        public InternetService()
        {
            NetworkInformation.NetworkStatusChanged += NetworkInformation_NetworkStatusChanged;
        }

        void NetworkInformation_NetworkStatusChanged(object sender)
        {
            isNetworkAvailable = NetworkInterface.GetIsNetworkAvailable();
            RaiseInternetAvailabilityChanged();
        }

        public event EventHandler InternetAvailabilityChanged;

        public void RaiseInternetAvailabilityChanged()
        {
            if (this.InternetAvailabilityChanged != null)
            {
                this.InternetAvailabilityChanged(this, new EventArgs());
            }
        }

        private bool isNetworkAvailable;
        public bool IsNetworkAvailable
        {
            get { return isNetworkAvailable; }
        }

        public void Initialize()
        {
            NetworkInformation_NetworkStatusChanged(this);
        }
    }
}
