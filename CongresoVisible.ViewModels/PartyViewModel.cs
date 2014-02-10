using Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CongresoVisible.ViewModels
{
    public class PartyViewModel : BindableBase
    {
        private int id = 0;
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                Set<int>(ref id, value);
            }
        }

        private string name = string.Empty;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Set<string>(ref name, value);
            }
        }

        private string logo = string.Empty;
        public string Logo
        {
            get
            {
                return this.logo;
            }
            set
            {
                Set<string>(ref logo, value);
            }
        }

        public ObservableCollection<PersonViewModel> People { get; set; }


        public System.Windows.Input.ICommand ShowPartyDetailsCommand
        {
            get { throw new NotImplementedException(); }
        }
    }
}
