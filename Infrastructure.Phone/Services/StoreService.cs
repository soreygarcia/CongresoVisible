using Infrastructure.Common.Contracts;
using Microsoft.Phone.Tasks;

namespace Infrastructure.Phone.Services
{
    public class StoreService : IStoreService
    {
        public void RateThisApp()
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }

        public void ShowDetailApp()
        {
            MarketplaceDetailTask marketplaceDetailTask = new MarketplaceDetailTask();

            marketplaceDetailTask.ContentIdentifier = "e502d52f-32bb-45b3-85b2-769ba36b82ef";
            marketplaceDetailTask.ContentType = MarketplaceContentType.Applications;

            marketplaceDetailTask.Show();
        }
    }
}