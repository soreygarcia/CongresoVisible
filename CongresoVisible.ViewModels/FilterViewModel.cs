using CongresoVisible.Contracts.ViewModels;
using Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.ViewModels
{
    public class FilterViewModel : BindableBase, IFilterViewModel
    {
        private string name = string.Empty;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                SetProperty(ref name, value);
            }
        }

        private string field = string.Empty;
        public string Field
        {
            get
            {
                return this.field;
            }
            set
            {
                SetProperty(ref field, value);
            }
        }

        private string value = string.Empty;
        public string Value
        {
            get
            {
                return this.value;
            }
            set
            {
                SetProperty(ref this.value, value);
            }
        }

        private bool isSelected;
        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                SetProperty(ref isSelected, value);
            }
        }


        public System.Windows.Input.ICommand GetPeopleCommand
        {
            get { throw new NotImplementedException(); }
        }
    }
}
