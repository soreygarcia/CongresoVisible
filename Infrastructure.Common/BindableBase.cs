using CongresoVisible.Contracts.Services;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Infrastructure.Common
{
    public abstract class BindableBase : INotifyPropertyChanged
    {
        private ServiceLocator serviceLocator = ServiceLocator.Instance;

        public ServiceLocator ServiceLocator
        {
            get
            {
                return this.serviceLocator;
            }
        }

        public T GetService<T>()
        {
            return this.serviceLocator.Resolve<T>();
        }

        public INavigationService Navigator { get; set; }

        public IInternetService NetworkMonitor { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
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
