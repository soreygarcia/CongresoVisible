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

namespace CongresoVisible.Infrastructure.Common
{
    public class ServiceLocator
    {
        private IContainer container;

        public ServiceLocator()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SettingsService>().As<ISettingsService>();

            builder.RegisterType<DbConnectionService>().As<IDbConnectionService>();
            builder.RegisterType<LocalFilesService>().As<ILocalFilesService>();
            builder.RegisterType<LocalDataService>().As<ILocalDataService>();

            builder.RegisterType<SocialService>().As<ISocialService>();
            builder.RegisterType<JsonService>().As<IJsonService>();
            builder.RegisterType<StoreService>().As<IStoreService>();

            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterType<NetworkService>().As<INetworkService>();

            container = builder.Build(Autofac.Builder.ContainerBuildOptions.None);

            builder.RegisterInstance(new MainViewModel(container)).As<MainViewModel>();
            builder.RegisterInstance(new PersonViewModel(container)).As<PersonViewModel>();
            builder.RegisterInstance(new AboutViewModel(container)).As<AboutViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return container.Resolve<MainViewModel>();
            }
        }

        public AboutViewModel About
        {
            get
            {
                return container.Resolve<AboutViewModel>();
            }
        }
    }
}
