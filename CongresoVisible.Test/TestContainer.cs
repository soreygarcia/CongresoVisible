using System;
using CongresoVisible.ViewModels;
using Infrastructure.Common.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using CongresoVisible.Models;
using CongresoVisible.Services.Contracts;

namespace CongresoVisible.Test
{
    [TestClass]
    public class TestContainer
    {
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

        #region PersonViewModel Test
        [TestMethod]
        public void ShareProfileTest()
        {
            PersonViewModel personViewModel = new PersonViewModel(socialService.Object, roamingService.Object, localDataService.Object);
            bool shared = false;
            personViewModel.WebUrl = "htt://blog.soreygarcia.me";
            socialService.Setup(p => p.ShareLink("Title", "Message", new Uri(personViewModel.WebUrl))).Callback(() =>
            {
                shared = true;
            });

            personViewModel.ShareProfileCommand.Execute(null);
            Assert.IsTrue(shared);
        }
        #endregion PersonViewModel Test

        #region MainViewModel Test
        [TestMethod]
        public void NavigationTest()
        {
            bool navigated = false;
            MainViewModel mainViewModel = new MainViewModel(jsonService.Object, networkService.Object, navigationService.Object);
            navigationService.Setup(p => p.Navigate<AboutViewModel>()).Callback(() =>
            {
                navigated = true;
                //Assert.AreEqual(type, typeof(AboutViewModel));
            });

            mainViewModel.ShowAboutInfoCommand.Execute(null);
            Assert.IsTrue(navigated);
        }

        [TestMethod]
        public void GetDataNetworkUnavailableTest()
        {
            MainViewModel mainViewModel = new MainViewModel(jsonService.Object, networkService.Object, navigationService.Object);
            networkService.SetupGet(p => p.IsNetworkAvailable).Returns(false);

            jsonService.Setup<Task<PartiesContainer>>(p => p.GetPartiesAsync())
                .ReturnsAsync(DataTestHelper.GetPartiesCollection());

            mainViewModel.GetPartiesCommand.Execute(null);
            Assert.IsNull(mainViewModel.Parties);
        }

        [TestMethod]
        public void GetDataNetworkAvailableTest()
        {
            MainViewModel mainViewModel = new MainViewModel(jsonService.Object, networkService.Object, navigationService.Object);
            networkService.SetupGet(p => p.IsNetworkAvailable).Returns(true);

            jsonService.Setup<Task<PartiesContainer>>(p => p.GetPartiesAsync())
                .ReturnsAsync(DataTestHelper.GetPartiesCollection());

            mainViewModel.GetPartiesCommand.Execute(null);
            Assert.IsNotNull(mainViewModel.Parties);
        }

        #endregion MainViewModel Test
    }
}
