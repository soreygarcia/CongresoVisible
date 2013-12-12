using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common
{
    public sealed class ServiceLocator 
    {
        private static readonly ServiceLocator instance = new ServiceLocator();
        private readonly static Dictionary<Type, object> services = new Dictionary<Type, object>();

        private ServiceLocator() { }

        public static ServiceLocator Instance
        {
            get
            {
                return instance;
            }
        }

        public void Register<T>(T resolver)
        {
            ServiceLocator.services[typeof(T)] = resolver;
        }

        public T Resolve<T>()
        {
            return (T)ServiceLocator.services[typeof(T)];
        }
    }
}
