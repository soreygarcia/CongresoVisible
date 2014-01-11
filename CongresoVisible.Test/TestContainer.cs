using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CongresoVisible.ViewModels;
using CongresoVisible.Contracts.ViewModels;
using CongresoVisible.Contracts.Services;
using CongresoVisible.FakeServices;
using System.Windows.Input;
using Infrastructure.Common.Contracts;

namespace CongresoVisible.Test
{
    [TestClass]
    public class TestContainer
    {
        IPersonViewModel personViewModel;
        IMainViewModel mainViewModel;

        [AssemblyInitialize]
        public static void RegisterServices(TestContext context)
        {
            ServiceLocator.Instance.Register<ISocialService>(new FakeSocialService());
            ServiceLocator.Instance.Register<IJsonService>(new FakeJsonService());
            ServiceLocator.Instance.Register<INavigationService>(new FakeNavigationService());
            ServiceLocator.Instance.Register<IInternetService>(new FakeInternetService());
            ServiceLocator.Instance.Register<IRoamingService>(new FakeRoamingService());
            ServiceLocator.Instance.Register<ISettingsService>(new FakeSettingsService());
            ServiceLocator.Instance.Register<IDbConnectionService>(new FakeDbConnectionService());
            ServiceLocator.Instance.Register<ILocalDataService>(new FakeLocalDataService());
        }

        [TestInitialize]
        public void Initialize()
        {
            personViewModel = new PersonViewModel();
            mainViewModel = new MainViewModel();
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
            var navigator = mainViewModel.GetService<INavigationService>() as FakeNavigationService;
            bool navigated = false;

            navigator.Callback = (type) =>
            {
                navigated = true;
                Assert.AreEqual(type, typeof(AboutViewModel));
            };

            mainViewModel.Navigator = navigator;
            mainViewModel.ShowAboutInfoCommand.Execute(null);
            Assert.IsTrue(navigated);
        }

        [TestMethod]
        public void GetDataNetworkUnavailableTest()
        {
            var internetService = mainViewModel.GetService<IInternetService>() as FakeInternetService;
            var jsonService = mainViewModel.GetService<IJsonService>() as FakeJsonService;
            bool dataLoaded = false;

            internetService.SetNetworkAvailability(false);
            mainViewModel.NetworkMonitor = internetService;

            jsonService.Callback = () =>
            {
                dataLoaded = true;
            };
            
            mainViewModel.GetFiltersCommand.Execute(null);
            Assert.IsFalse(dataLoaded);
        }

        [TestMethod]
        public void GetDataNetworkAvailableTest()
        {
            var internetService = mainViewModel.GetService<IInternetService>() as FakeInternetService;
            var jsonService = mainViewModel.GetService<IJsonService>() as FakeJsonService;
            bool dataLoaded = false;

            internetService.SetNetworkAvailability(true);
            mainViewModel.NetworkMonitor = internetService;

            jsonService.Callback = () =>
            {
                dataLoaded = true;
                Assert.AreEqual(true, internetService.isNetworkAvailable);
            };

            mainViewModel.GetFiltersCommand.Execute(null);
            Assert.IsTrue(dataLoaded);
        }

        #endregion MainViewModel Test

        #region PersonViewModel Test
        [TestMethod]
        public void ShareProfileTest()
        {
            personViewModel.WebUrl = "htt://blog.soreygarcia.me";

            var socialService = personViewModel.GetService<ISocialService>() as FakeSocialService;
            bool shared = false;

            socialService.Callback = () =>
            {
                shared = true;
            };

            personViewModel.ShareProfileCommand.Execute(null);
            Assert.IsTrue(shared);
        }
        #endregion PersonViewModel Test
    }
}
