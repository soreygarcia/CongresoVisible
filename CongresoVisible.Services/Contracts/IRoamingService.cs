using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Services.Contracts
{
    public interface IRoamingService
    {
        List<int> GetFollowing();
        void FollowPerson(int id);
        void UnfollowPerson(int id);
        string SignIn();
    }
}
