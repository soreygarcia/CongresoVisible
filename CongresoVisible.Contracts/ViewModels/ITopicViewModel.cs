using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CongresoVisible.Contracts.Common;

namespace CongresoVisible.Contracts.ViewModels
{
    public interface ITopicViewModel : IServiceLocator
    {
        string Name { get; set; }
        bool Position { get; set; }
        string Url { get; set; }
        int PresentedProjects { get; set; }
    }
}
