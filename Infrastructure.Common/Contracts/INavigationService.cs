using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Contracts
{   
    public interface INavigationService
    {
        void Navigate<T>();
        void Navigate<T>(object parameter);
        void GoBack();
    }
}
