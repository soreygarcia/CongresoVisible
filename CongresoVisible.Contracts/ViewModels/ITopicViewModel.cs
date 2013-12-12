using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CongresoVisible.Contracts.ViewModels.Common;

namespace CongresoVisible.Contracts.ViewModels
{
    public interface ITopicViewModel : IBindableServiceLocator
    {
        bool Position { get; set; }
        string Name { get; set; }
        string Url { get; set; }
        int PresentedProjects { get; set; }
    }
}
