using CongresoVisible.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Phone.Tasks;

namespace CongresoVisible.Phone.Services
{
    public class SocialService : ISocialService
    {
        public void ShareLink(string title, string message, Uri url)
        {
            ShareLinkTask shareLinkTask = new ShareLinkTask();

            shareLinkTask.Title = title;
            shareLinkTask.LinkUri = url;
            shareLinkTask.Message = message;

            shareLinkTask.Show();
        }

        public void ShareMessage(string message)
        {
            ShareStatusTask shareStatusTask = new ShareStatusTask();
            shareStatusTask.Status = message;

            shareStatusTask.Show();
        }
    }
}
