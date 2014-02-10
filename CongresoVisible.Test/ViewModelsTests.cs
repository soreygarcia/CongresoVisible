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
using CongresoVisible.Test.Helpers;

namespace CongresoVisible.Test
{
    [TestClass]
    public class ViewModelsTests
    {        
        #region PersonViewModel Test
        [TestMethod]
        public void ShareProfile_TestRight()
        {
            PersonViewModel personViewModel = new PersonViewModel();
            personViewModel.WebUrl = "htt://blog.soreygarcia.me";

            personViewModel.ShareProfileCommand.Execute(null);
            MocksContainer.socialService
                .Verify(p => p.ShareLink(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Uri>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(UriFormatException))]
        public void ShareProfile_TestFail()
        {
            PersonViewModel personViewModel = new PersonViewModel();
            personViewModel.ShareProfileCommand.Execute(null);
        }
        #endregion PersonViewModel Test

        #region MainViewModel Test
        [TestMethod]
        public void Navigation_TestRight()
        {
            MainViewModel mainViewModel = new MainViewModel();

            mainViewModel.ShowAboutInfoCommand.Execute(null);
            MocksContainer.navigationService.Verify(p => p.Navigate<AboutViewModel>(), Times.Once);
        }

        [TestMethod]
        public void GetDataNetwork_UnavailableTest()
        {
            MainViewModel mainViewModel = new MainViewModel();
            MocksContainer.networkService.SetupGet(p => p.IsNetworkAvailable).Returns(false);

            MocksContainer.jsonService.Setup<Task<PartiesContainer>>(p => p.GetPartiesAsync())
                .ReturnsAsync(TestDataHelper.GetObject<PartiesContainer>());

            mainViewModel.GetPartiesCommand.Execute(null);
            Assert.IsNull(mainViewModel.Parties);
        }

        [TestMethod]
        public void GetDataNetwork_AvailableTest()
        {
            MainViewModel mainViewModel = new MainViewModel();
            MocksContainer.networkService.SetupGet(p => p.IsNetworkAvailable).Returns(true);

            MocksContainer.jsonService.Setup<Task<PartiesContainer>>(p => p.GetPartiesAsync())
                .ReturnsAsync(TestDataHelper.GetObject<PartiesContainer>());

            mainViewModel.GetPartiesCommand.Execute(null);
            Assert.IsNotNull(mainViewModel.Parties);
        }

        #endregion MainViewModel Test
    }
}
