using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CongresoVisible.Contracts.Services;
using CongresoVisible.FakeServices.Contracts;

namespace CongresoVisible.FakeServices
{
    public class FakeStoreService : IStoreService, IFakeService
    {
        public Action Callback { get; set; }

        public void RateThisApp()
        {
            Callback();
        }
    }
}
