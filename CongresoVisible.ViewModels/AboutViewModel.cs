using Autofac;
using Infrastructure.Common;
using Infrastructure.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.ViewModels
{
    public class AboutViewModel : BindableBase
    {
        public AboutViewModel(IContainer container)
        {
            this.SetContainer(container);
            this.Navigator = GetService<INavigationService>();
        }

        public System.Windows.Input.ICommand SendEmailCommand
        {
            get { throw new NotImplementedException(); }
        }

        public System.Windows.Input.ICommand RateThisAppCommand
        {
            get { throw new NotImplementedException(); }
        }
    }
}
