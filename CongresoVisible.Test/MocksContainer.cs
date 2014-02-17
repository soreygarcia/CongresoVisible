using System;
using CongresoVisible.ViewModels;
using Infrastructure.Common.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using CongresoVisible.Models;
using CongresoVisible.Services.Contracts;
using Autofac;
using Infrastructure.Common;
using Contracts = CongresoVisible.Services.Contracts;

namespace CongresoVisible.Test
{
    [TestClass]
    public class MocksContainer
    {
        public static IContainer container;

        public static Mock<IDbConnectionService> DbConnectionService;
        public static Mock<ISettingsService> SettingsService;
        public static Mock<Contracts.IJsonService> jsonService;
        public static Mock<ISocialService> socialService;
        public static Mock<INavigationService> navigationService;
        public static Mock<INetworkService> networkService;
        public static Mock<ILocalDataService> localDataService;
        public static Mock<IHttpClientService> httpClientService;

        [AssemblyInitialize]
        public static void RegisterServices(TestContext context)
        {
            DbConnectionService = new Mock<IDbConnectionService>();
            SettingsService = new Mock<ISettingsService>();
            jsonService = new Mock<Contracts.IJsonService>();
            socialService = new Mock<ISocialService>();
            navigationService = new Mock<INavigationService>();
            networkService = new Mock<INetworkService>();
            localDataService = new Mock<ILocalDataService>();
            httpClientService = new Mock<IHttpClientService>();

            var builder = new ContainerBuilder();

            builder.RegisterInstance(SettingsService.Object).As<ISettingsService>();
            builder.RegisterInstance(DbConnectionService.Object).As<IDbConnectionService>();
            builder.RegisterInstance(localDataService.Object).As<ILocalDataService>();
            builder.RegisterInstance(socialService.Object).As<ISocialService>();
            builder.RegisterInstance(jsonService.Object).As<Contracts.IJsonService>();
            builder.RegisterInstance(navigationService.Object).As<INavigationService>();
            builder.RegisterInstance(networkService.Object).As<INetworkService>();
            builder.RegisterInstance(httpClientService.Object).As<IHttpClientService>();

            container = builder.Build(Autofac.Builder.ContainerBuildOptions.None);
            BindableBase.Container = container;
        }
    }
}
