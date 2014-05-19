using Infrastructure.Common.Contracts;
using System;
using System.Net.NetworkInformation;
using Windows.Networking.Connectivity;

namespace Infrastructure.Phone.Services
{
    public class NetworkService : INetworkService
    {
        public NetworkService()
        {
            NetworkInformation.NetworkStatusChanged += NetworkInformation_NetworkStatusChanged;
        }

        void NetworkInformation_NetworkStatusChanged(object sender)
        {
            isNetworkAvailable = NetworkInterface.GetIsNetworkAvailable();
            RaiseInternetAvailabilityChanged();
        }

        public event EventHandler NetworkAvailabilityChanged;

        public void RaiseInternetAvailabilityChanged()
        {
            if (this.NetworkAvailabilityChanged != null)
            {
                this.NetworkAvailabilityChanged(this, new EventArgs());
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