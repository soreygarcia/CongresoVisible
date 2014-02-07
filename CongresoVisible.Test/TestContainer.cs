using CongresoVisible.Contracts.Services;
using CongresoVisible.Contracts.ViewModels;
using CongresoVisible.ViewModels;
using Infrastructure.Common.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CongresoVisible.Test
{
    [TestClass]
    public class TestContainer
    {
        IPersonViewModel personViewModel;
        IMainViewModel mainViewModel;

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
            personViewModel = new PersonViewModel(socialService.Object, roamingService.Object, localDataService.Object);
            mainViewModel = new MainViewModel(jsonService.Object);
        }

        [TestMethod]
        public void CreateInstance()
        {
            Assert.IsInstanceOfType(personViewModel, typeof(PersonViewModel));
            Assert.IsInstanceOfType(mainViewModel, typeof(MainViewModel));
        }

        #region MainViewModel Test
        [TestMethod]
        public void NavigationTest()
        {
            bool navigated = false;

            //navigator.Callback = (type) =>
            //{
            //    navigated = true;
            //    Assert.AreEqual(type, typeof(AboutViewModel));
            //};

            //mainViewModel.Navigator = navigator;
            mainViewModel.ShowAboutInfoCommand.Execute(null);
            Assert.IsTrue(navigated);
        }

        [TestMethod]
        public void GetDataNetworkUnavailableTest()
        {
            bool dataLoaded = false;
            //networkService.SetNetworkAvailability(false);
            //jsonService.Callback = () =>
            //{
            //    dataLoaded = true;
            //};
            
            mainViewModel.GetFiltersCommand.Execute(null);
            Assert.IsFalse(dataLoaded);
        }

        [TestMethod]
        public void GetDataNetworkAvailableTest()
        {
            bool dataLoaded = false;

            //networkService.SetNetworkAvailability(true);
            //mainViewModel.NetworkMonitor = networkService;

            //jsonService.Callback = () =>
            //{
            //    dataLoaded = true;
            //    Assert.AreEqual(true, networkService.isNetworkAvailable);
            //};

            mainViewModel.GetFiltersCommand.Execute(null);
            Assert.IsTrue(dataLoaded);
        }

        #endregion MainViewModel Test

        #region PersonViewModel Test
        [TestMethod]
        public void ShareProfileTest()
        {
            personViewModel.WebUrl = "htt://blog.soreygarcia.me";

            //var socialService = personViewModel.GetService<ISocialService>() as FakeSocialService;
            bool shared = false;

            //socialService.Callback = () =>
            //{
            //    shared = true;
            //};

            personViewModel.ShareProfileCommand.Execute(null);
            Assert.IsTrue(shared);
        }
        #endregion PersonViewModel Test
    }
}
