using CongresoVisible.Contracts.ViewModels;
using Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.ViewModels
{
    public class AboutViewModel : BindableBase, IAboutViewModel
    {
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
