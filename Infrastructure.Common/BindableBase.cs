using Autofac;
using Infrastructure.Common.Contracts;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Infrastructure.Common
{
    public abstract class BindableBase : INotifyPropertyChanged
    {
        public static IContainer Container { get; set; }

        protected T GetService<T>()
        {
            return Container.Resolve<T>();
        }

        protected T GetViewModel<T>()
        {
            return Container.Resolve<T>();
        }

        public INavigationService Navigator { get; set; }

        private INetworkService networkMonitor;

        public INetworkService NetworkMonitor 
        {
            get 
            {
                return networkMonitor;
            }
            set 
            {
                networkMonitor = value;
                networkMonitor.Initialize();
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Set<T>(ref T storage, T value = default(T), [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
