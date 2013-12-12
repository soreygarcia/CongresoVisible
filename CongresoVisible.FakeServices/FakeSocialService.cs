using CongresoVisible.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.FakeServices
{
    public class FakeSocialService : ISocialService
    {
        public Action Callback { get; set; }

        public void ShareLink(string title, string message, Uri url)
        {
            Callback();
        }

        public void ShareMessage(string message)
        {
            Callback();
        }
    }
}
