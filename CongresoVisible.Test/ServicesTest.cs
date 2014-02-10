using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using Moq;
using CongresoVisible.Services.Contracts;
using Services = CongresoVisible.Services;
using Contracts = CongresoVisible.Services.Contracts;
using System.Threading.Tasks;
using CongresoVisible.Test.Helpers;

namespace CongresoVisible.Test
{
    [TestClass]
    public class ServicesTest
    {
        [TestMethod]
        public async Task GetPerson_WithResult()
        {
            Services.JsonService jsonService = 
                new Services.JsonService(MocksContainer.settingsService.Object, MocksContainer.httpClientService.Object);

            MocksContainer.settingsService
                .Setup(p => p.GetSettingsValue("PersonServiceUrl"))
                .Returns(DataTestHelper.GetAnyString());

            MocksContainer.httpClientService
                .Setup<Task<string>>(p => p.GetStringAsync(It.IsAny<string>()))
                .ReturnsAsync(DataTestHelper.GetSerializedPerson());

            var person = await jsonService.GetPersonAsync(It.IsAny<int>());

            Assert.IsNotNull(person);
        }

        [TestMethod]
        public async Task GetPerson_WithoutResult()
        {
            Services.JsonService jsonService =
                new Services.JsonService(MocksContainer.settingsService.Object, MocksContainer.httpClientService.Object);

            MocksContainer.settingsService
                .Setup(p => p.GetSettingsValue("PersonServiceUrl"))
                .Returns(DataTestHelper.GetAnyString());

            MocksContainer.httpClientService
                .Setup<Task<string>>(p => p.GetStringAsync(It.IsAny<string>()))
                .ReturnsAsync(DataTestHelper.GetNotFound());

            var person = await jsonService.GetPersonAsync(It.IsAny<int>());

            Assert.IsNull(person);
        }
    }
}
