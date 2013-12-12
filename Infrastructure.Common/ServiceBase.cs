using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common
{
    public abstract class ServiceBase
    {
        private ServiceLocator serviceLocator = ServiceLocator.Instance;
        public ServiceLocator ServiceLocator
        {
            get
            {
                return this.serviceLocator;
            }
        }

        public T GetContext<T>()
        {
            return this.serviceLocator.Resolve<T>();
        }

        public T GetService<T>()
        {
            return GetContext<T>();
        }
    }
}
