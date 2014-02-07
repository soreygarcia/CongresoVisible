using CongresoVisible.Contracts.Services;
using Infrastructure.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CongresoVisible.Phone.Services
{
    public class NavigationService : INavigationService
    {
        public void Navigate<T>()
        {
            (Application.Current.RootVisual as Frame)
                .Navigate(new Uri("/" + typeof(T).Name, UriKind.Relative));
        }

        public void Navigate<T>(object parameter)
        {
            throw new NotImplementedException();
        }

        public void GoBack()
        {
            throw new NotImplementedException();
        }
    }
}
