using Infrastructure.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace CongresoVisible.Contracts.ViewModels
{
    public interface IMainViewModel : INavigateViewModel
    {
        IPersonViewModel SelectedPerson { get; set; }

        ObservableCollection<IFilterViewModel> Filters { get; set; }
        ObservableCollection<IPartyViewModel> Parties { get; set; }
        ObservableCollection<IPersonViewModel> People { get; set; }
        ObservableCollection<IPersonViewModel> Following { get; set; }

        ICommand ShowAboutInfoCommand { get; }
        ICommand GetFiltersCommand { get; }
        ICommand GetFollowingPeopleCommand { get; }
        ICommand GetRandomPeopleCommand { get; }
        ICommand GetPartiesCommand { get; }
        ICommand GetPeopleByPartyCommand { get; }
    }
}
