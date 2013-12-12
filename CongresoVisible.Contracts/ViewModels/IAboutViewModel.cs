using System.Windows.Input;
using CongresoVisible.Contracts.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Contracts.ViewModels
{
    public interface IAboutViewModel : IBindableServiceLocator, INavigateViewModel
    {
        ICommand SendEmailCommand { get; }
        ICommand RateThisAppCommand { get; }
    }
}
