using CongresoVisible.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.FakeServices
{
    public class FakeRoamingService : IRoamingService
    {
        public Action Callback { get; set; }

        public List<int> GetFollowing()
        {
            Callback();
            return new List<int>();
        }

        public string SignIn()
        {
            Callback();
            return string.Empty;
        }
        
        public void FollowPerson(int id)
        {
            Callback();
        }

        public void UnfollowPerson(int id)
        {
            Callback();
        }
    }
}
