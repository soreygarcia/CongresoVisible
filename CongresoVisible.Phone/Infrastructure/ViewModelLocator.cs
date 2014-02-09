using Autofac;
using CongresoVisible.Services.Contracts;
using CongresoVisible.Services;
using CongresoVisible.ViewModels;
using Infrastructure.Common;
using Infrastructure.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using Autofac.Extras.CommonServiceLocator;

namespace CongresoVisible.Infrastructure.Common
{
    public class ViewModelLocator
    {
        private IContainer container;

        public ViewModelLocator()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SettingsService>().As<ISettingsService>();
            builder.RegisterType<DbConnectionService>().As<IDbConnectionService>();
            builder.RegisterType<LocalDataService>().As<ILocalDataService>();
            builder.RegisterType<LocalFilesService>().As<ILocalFilesService>();
            builder.RegisterType<RoamingService>().As<IRoamingService>();
            builder.RegisterType<SocialService>().As<ISocialService>();
            builder.RegisterType<JsonService>().As<IJsonService>();
            builder.RegisterType<StoreService>().As<IStoreService>();
            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterType<NetworkService>().As<INetworkService>();

            builder.RegisterType<MainViewModel>().As<MainViewModel>();
            builder.RegisterType<PersonViewModel>().As<PersonViewModel>();
            builder.RegisterType<AboutViewModel>().As<AboutViewModel>();

            container = builder.Build(Autofac.Builder.ContainerBuildOptions.None);

            //ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
            BindableBase.Container = container;

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public AboutViewModel About
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AboutViewModel>();
            }
        }
    }
}
