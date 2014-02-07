using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Contracts
{
    public interface INavigatedViewModel
    {
        INavigationService Navigator { get; set; }
        INetworkService NetworkMonitor { get; set; }
    }
}
