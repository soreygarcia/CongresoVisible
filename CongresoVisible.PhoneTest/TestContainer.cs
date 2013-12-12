using System;
using System.Windows.Input;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using CongresoVisible.ViewModels;

namespace CongresoVisible.PhoneTest
{
    [TestClass]
    public class TestContainer
    {
        [TestMethod]
        public void TestNavigate()
        {
            var vm = new MainViewModel();
            ICommand command = vm.ShowAboutInfoCommand;
            
            var navigated = false;
            vm.Navigator = new FakeServices.FakeNavigationService
            {
                Callback = (type) =>
                {
                    navigated = true;
                    Assert.AreEqual(type, typeof(AboutViewModel));
                }
            };

            command.Execute(null);

            Assert.IsTrue(navigated);
        }
    }
}
