using Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.ViewModels
{
    public class FilterViewModel : BindableBase
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
                Set<string>(ref name, value);
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
                Set<string>(ref field, value);
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
                Set<string>(ref this.value, value);
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
                Set<bool>(ref isSelected, value);
            }
        }


        public System.Windows.Input.ICommand GetPeopleCommand
        {
            get { throw new NotImplementedException(); }
        }
    }
}
