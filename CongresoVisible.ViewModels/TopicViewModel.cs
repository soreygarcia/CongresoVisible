using Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.ViewModels
{
    public class TopicViewModel : BindableBase
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
                Set<bool>(ref position, value);
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
                Set<string>(ref name, value);
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
                Set<string>(ref url, value);
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
                Set<int>(ref presentedProjects, value);
            }
        }
    }
}
