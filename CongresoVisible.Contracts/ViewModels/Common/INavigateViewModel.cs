using CongresoVisible.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Contracts.ViewModels.Common
{
    public interface INavigateViewModel
    {
        INavigationService Navigator { get; set; }
        IInternetService NetworkMonitor { get; set; }
    }
}
