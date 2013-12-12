using CongresoVisible.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CongresoVisible.Contracts.ViewModels
{
    public interface IFilterViewModel : IServiceLocator, INavigateViewModel
    {
        string Name { get; set; }
        string Field { get; set; }
        string Value { get; set; }
        bool IsSelected { get; set; }

        ICommand GetPeopleCommand { get; }
    }
}
