using Autofac;
using CongresoVisible.Contracts.Services;
using CongresoVisible.Contracts.ViewModels;
using CongresoVisible.Phone.Services;
using CongresoVisible.Services;
using CongresoVisible.ViewModels;
using Infrastructure.Common;
using Infrastructure.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Phone.Infrastructure
{
    public class ServiceLocator
    {
        private static IContainer Container { get; set; }

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

            builder.RegisterType<MainViewModel>().As<IMainViewModel>();
            builder.RegisterType<AboutViewModel>().As<IAboutViewModel>();
        }

        public IMainViewModel Main
        {
            get
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    return scope.Resolve<IMainViewModel>();
                }
            }
        }

        public IAboutViewModel About
        {
            get
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    return scope.Resolve<IAboutViewModel>();
                }
            }
        }
    }
}
