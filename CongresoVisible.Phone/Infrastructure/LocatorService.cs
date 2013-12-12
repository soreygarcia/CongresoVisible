﻿using CongresoVisible.Contracts.Services;
using CongresoVisible.Contracts.ViewModels;
using CongresoVisible.Services;
using CongresoVisible.ViewModels;
using Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Phone.Infrastructure
{
    public class LocatorService
    {
        public LocatorService()
        {
            ServiceLocator.Instance.Register<ISocialService>(new SocialService());
            ServiceLocator.Instance.Register<IJsonService>(new JsonService());
            ServiceLocator.Instance.Register<ISettingsService>(new SettingsService());

            INavigationService navigator = new NavigatorService();
            ServiceLocator.Instance.Register<INavigationService>(navigator);

            IInternetService internetService = new InternetService();
            internetService.Initialize();
            ServiceLocator.Instance.Register<IInternetService>(internetService);

            var mainViewModel = new MainViewModel() { Navigator = navigator, NetworkMonitor = internetService };

            ServiceLocator.Instance.Register<IMainViewModel>(mainViewModel);
            
            ServiceLocator.Instance.Register<IAboutViewModel>(new AboutViewModel() { Navigator = navigator });
        }

        public IMainViewModel Main
        {
            get
            {
                return ServiceLocator.Instance.Resolve<IMainViewModel>();
            }
        }

        public IAboutViewModel About
        {
            get
            {
                return ServiceLocator.Instance.Resolve<IAboutViewModel>();
            }
        }
    }
}
