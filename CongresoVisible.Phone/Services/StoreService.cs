using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CongresoVisible.Services.Contracts;
using Microsoft.Phone.Tasks;

namespace CongresoVisible.Phone.Services
{
    public class StoreService : IStoreService
    {
        public void RateThisApp()
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }
    }
}
