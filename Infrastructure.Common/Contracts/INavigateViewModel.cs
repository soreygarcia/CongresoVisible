using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Contracts
{
    public interface INavigateViewModel
    {
        INavigationService Navigator { get; set; }
        IInternetService NetworkMonitor { get; set; }
    }
}
