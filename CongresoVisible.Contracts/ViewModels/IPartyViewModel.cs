using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Infrastructure.Common.Contracts;

namespace CongresoVisible.Contracts.ViewModels
{
    public interface IPartyViewModel : INavigateViewModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string Logo { get; set; }
        ObservableCollection<IPersonViewModel> People { get; set; }
        ICommand ShowPartyDetailsCommand { get; }
    }
}
