using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CongresoVisible.ViewModels;

namespace CongresoVisible.Phone.Pages
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            (this.DataContext as MainViewModel).Initialize();
        }

        private void btnAbout_Click(object sender, System.EventArgs e)
        {
            (this.DataContext as MainViewModel).ShowAboutInfo();
        }
    }
}