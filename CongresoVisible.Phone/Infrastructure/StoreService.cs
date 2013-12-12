using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CongresoVisible.Contracts.Services;
using Microsoft.Phone.Tasks;

namespace CongresoVisible.Phone.Infrastructure
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
