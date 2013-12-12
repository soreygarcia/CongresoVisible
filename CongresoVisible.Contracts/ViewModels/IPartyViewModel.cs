using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using CongresoVisible.Contracts.ViewModels.Common;
using System.Windows.Input;

namespace CongresoVisible.Contracts.ViewModels
{
    public interface IPartyViewModel : IBindableServiceLocator, INavigateViewModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string Logo { get; set; }

        ObservableCollection<IPersonViewModel> People { get; set; }

        ICommand ShowPartyDetailsCommand { get; }
    }
}
