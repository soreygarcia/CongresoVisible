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
using Contracts = CongresoVisible.Services.Contracts;
using Infrastructure.Common.Services;

namespace CongresoVisible.Infrastructure
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
            
            builder.RegisterType<SocialService>().As<ISocialService>();
            builder.RegisterType<Services.JsonService>().As<Contracts.IJsonService>();
            builder.RegisterType<StoreService>().As<IStoreService>();
            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterType<NetworkService>().As<INetworkService>();
            builder.RegisterType<HttpClientService>().As<IHttpClientService>();

            builder.RegisterType<MainViewModel>().As<MainViewModel>().SingleInstance();
            builder.RegisterType<PersonViewModel>().As<PersonViewModel>().SingleInstance();
            builder.RegisterType<AboutViewModel>().As<AboutViewModel>().SingleInstance();

            container = builder.Build(Autofac.Builder.ContainerBuildOptions.None);
            BindableBase.Container = container;
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
