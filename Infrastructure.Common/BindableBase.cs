using Autofac;
using GalaSoft.MvvmLight;
using Infrastructure.Common.Contracts;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Infrastructure.Common
{
    public abstract class BindableBase : ViewModelBase 
    {
        public static IContainer Container { get; set; }

        protected T GetService<T>()
        {
            return Container.Resolve<T>();
        }

        public INavigationService Navigator { get; set; }

        public INetworkService NetworkMonitor { get; set; }
    }
}
