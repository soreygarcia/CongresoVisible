﻿using CongresoVisible.Services.Contracts;
using Infrastructure.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace CongresoVisible.Services
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
