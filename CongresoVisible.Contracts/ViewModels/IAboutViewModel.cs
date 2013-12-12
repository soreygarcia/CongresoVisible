using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CongresoVisible.Contracts.Common;

namespace CongresoVisible.Contracts.ViewModels
{
    public interface IAboutViewModel : IServiceLocator, INavigateViewModel
    {
        ICommand SendEmailCommand { get; }
        ICommand RateThisAppCommand { get; }
    }
}
