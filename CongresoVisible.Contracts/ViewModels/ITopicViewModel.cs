using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Contracts.ViewModels
{
    public interface ITopicViewModel 
    {
        string Name { get; set; }
        bool Position { get; set; }
        string Url { get; set; }
        int PresentedProjects { get; set; }
    }
}
