using CongresoVisible.Contracts.ViewModels;
using Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.ViewModels
{
    public class TopicViewModel : BindableBase, ITopicViewModel
    {
        private bool position;
        public bool Position
        {
            get
            {
                return this.position;
            }
            set
            {
                SetProperty(ref position, value);
            }
        }

        private string name = string.Empty;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                SetProperty(ref name, value);
            }
        }

        private string url = string.Empty;
        public string Url
        {
            get
            {
                return this.url;
            }
            set
            {
                SetProperty(ref url, value);
            }
        }

        private int presentedProjects = 0;
        public int PresentedProjects
        {
            get
            {
                return this.presentedProjects;
            }
            set
            {
                SetProperty(ref presentedProjects, value);
            }
        }
    }
}
