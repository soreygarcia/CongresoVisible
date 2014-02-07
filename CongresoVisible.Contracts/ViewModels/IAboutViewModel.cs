using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Common.Contracts;

namespace CongresoVisible.Contracts.ViewModels
{
    public interface IAboutViewModel : INavigateViewModel
    {
        ICommand SendEmailCommand { get; }
        ICommand RateThisAppCommand { get; }
    }
}
