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

        public static Mock<IDbConnectionService> dbConnectionService;
        public static Mock<ISettingsService> settingsService;
        public static Mock<Contracts.IJsonService> jsonService;
        public static Mock<ISocialService> socialService;
        public static Mock<INavigationService> navigationService;
        public static Mock<INetworkService> networkService;
        public static Mock<IRoamingService> roamingService;
        public static Mock<ILocalDataService> localDataService;
        public static Mock<IHttpClientService> httpClientService;

        [AssemblyInitialize]
        public static void RegisterServices(TestContext context)
        {
            dbConnectionService = new Mock<IDbConnectionService>();
            settingsService = new Mock<ISettingsService>();
            jsonService = new Mock<Contracts.IJsonService>();
            socialService = new Mock<ISocialService>();
            navigationService = new Mock<INavigationService>();
            networkService = new Mock<INetworkService>();
            roamingService = new Mock<IRoamingService>();
            localDataService = new Mock<ILocalDataService>();
            httpClientService = new Mock<IHttpClientService>();

            var builder = new ContainerBuilder();

            builder.RegisterInstance(settingsService.Object).As<ISettingsService>();
            builder.RegisterInstance(dbConnectionService.Object).As<IDbConnectionService>();
            builder.RegisterInstance(roamingService.Object).As<IRoamingService>();
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
