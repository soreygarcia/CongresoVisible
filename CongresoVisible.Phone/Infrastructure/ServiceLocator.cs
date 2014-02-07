﻿using Autofac;
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

            builder.RegisterType<MainViewModel>();
            builder.RegisterType<AboutViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return Container.Resolve<MainViewModel>();
            }
        }

        public AboutViewModel About
        {
            get
            {
                return Container.Resolve<AboutViewModel>();
            }
        }
    }
}
