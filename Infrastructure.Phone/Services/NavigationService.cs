using Infrastructure.Common.Contracts;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Infrastructure.Phone.Services
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
            if ((Application.Current.RootVisual as Frame).CanGoBack)
                (Application.Current.RootVisual as Frame).GoBack();
        }
    }
}