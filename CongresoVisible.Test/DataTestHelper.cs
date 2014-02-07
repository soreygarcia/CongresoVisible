using CongresoVisible.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Test
{
    class DataTestHelper
    {
        public static PartiesContainer GetPartiesCollection()
        {
            return new PartiesContainer()
            {
                results = new System.Collections.Generic.List<Party>()
            };
        }
    }
}
