using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.FakeServices.Contracts
{
    public interface IFakeService
    {
        Action Callback { get; set; }
    }
}
