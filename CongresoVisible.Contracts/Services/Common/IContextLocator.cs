using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Contracts.Services.Common
{
    public interface IContextLocator 
    {
        T GetContext<T>();
        T GetService<T>();
    }
}
