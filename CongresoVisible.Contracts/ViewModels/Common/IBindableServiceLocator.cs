using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Contracts.ViewModels.Common
{
    public interface IBindableServiceLocator
    {
        T GetService<T>();
    }
}
