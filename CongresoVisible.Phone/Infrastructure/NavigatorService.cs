using CongresoVisible.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CongresoVisible.Phone.Infrastructure
{
    public class NavigatorService : INavigationService
    {
        public void Navigate<T>()
        {
            (Application.Current.RootVisual as Frame)
                .Navigate(new Uri("/" + typeof(T).Name, UriKind.Relative));
        }
    }
}
