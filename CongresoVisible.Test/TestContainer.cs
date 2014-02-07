using System;
using CongresoVisible.ViewModels;
using Infrastructure.Common.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using CongresoVisible.Models;
using CongresoVisible.Services.Contracts;
using Autofac;

namespace CongresoVisible.Test
{
    [TestClass]
    public class TestContainer
    {
        private static IContainer container;

        private static Mock<IDbConnectionService> dbConnectionService;
        private static Mock<ISettingsService> settingsService;
        private static Mock<IJsonService> jsonService;
        private static Mock<ISocialService> socialService;
        private static Mock<INavigationService> navigationService;
        private static Mock<INetworkService> networkService;
        private static Mock<IRoamingService> roamingService;
        private static Mock<ILocalDataService> localDataService;
        
        [AssemblyInitialize]
        public static void RegisterServices(TestContext context)
        {
            dbConnectionService = new Mock<IDbConnectionService>();
            settingsService = new Mock<ISettingsService>();
            jsonService = new Mock<IJsonService>();
            socialService = new Mock<ISocialService>();
            navigationService = new Mock<INavigationService>();
            networkService = new Mock<INetworkService>();
            roamingService = new Mock<IRoamingService>();
            localDataService = new Mock<ILocalDataService>();
        }

        [TestInitialize]
        public void Initialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(settingsService.Object).As<ISettingsService>();
            builder.RegisterInstance(dbConnectionService.Object).As<IDbConnectionService>();

            builder.RegisterInstance(socialService.Object).As<ISocialService>();
            builder.RegisterInstance(jsonService.Object).As<IJsonService>();

            builder.RegisterInstance(navigationService.Object).As<INavigationService>();
            builder.RegisterInstance(networkService.Object).As<INetworkService>();

            container = builder.Build(Autofac.Builder.ContainerBuildOptions.None);
        }

        #region PersonViewModel Test
        [TestMethod]
        public void ShareProfileTest()
        {
            PersonViewModel personViewModel = new PersonViewModel(container);
            personViewModel.WebUrl = "htt://blog.soreygarcia.me";

            personViewModel.ShareProfileCommand.Execute(null);
            socialService.Verify(p => p.ShareLink(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Uri>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(UriFormatException))]
        public void ShareProfileTestFail()
        {
            PersonViewModel personViewModel = new PersonViewModel(container);
            personViewModel.ShareProfileCommand.Execute(null);
        }
        #endregion PersonViewModel Test

        #region MainViewModel Test
        [TestMethod]
        public void NavigationTest()
        {
            MainViewModel mainViewModel = new MainViewModel(container);

            mainViewModel.ShowAboutInfoCommand.Execute(null);
            navigationService.Verify(p => p.Navigate<AboutViewModel>(), Times.Once);
        }

        [TestMethod]
        public void GetDataNetworkUnavailableTest()
        {
            MainViewModel mainViewModel = new MainViewModel(container);
            networkService.SetupGet(p => p.IsNetworkAvailable).Returns(false);

            jsonService.Setup<Task<PartiesContainer>>(p => p.GetPartiesAsync())
                .ReturnsAsync(DataTestHelper.GetPartiesCollection());

            mainViewModel.GetPartiesCommand.Execute(null);
            Assert.IsNull(mainViewModel.Parties);
        }

        [TestMethod]
        public void GetDataNetworkAvailableTest()
        {
            MainViewModel mainViewModel = new MainViewModel(container);
            networkService.SetupGet(p => p.IsNetworkAvailable).Returns(true);

            jsonService.Setup<Task<PartiesContainer>>(p => p.GetPartiesAsync())
                .ReturnsAsync(DataTestHelper.GetPartiesCollection());

            mainViewModel.GetPartiesCommand.Execute(null);
            Assert.IsNotNull(mainViewModel.Parties);
        }

        #endregion MainViewModel Test
    }
}
