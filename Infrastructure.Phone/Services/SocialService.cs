using Infrastructure.Common.Contracts;
using Microsoft.Phone.Tasks;
using System;

namespace Infrastructure.Phone.Services
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

        public void SendEmail(string subject, string to)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();

            emailComposeTask.Subject = subject;
            emailComposeTask.To = to;
            
            emailComposeTask.Show();
        }
    }
}