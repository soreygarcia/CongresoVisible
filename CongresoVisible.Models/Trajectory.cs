using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Models
{
    public class Trajectory
    {
        public int years_in_congress { get; set; }
        public int politic_control_summonses { get; set; }
        public List<Project> highlighted_projects { get; set; }
        public List<MainTopic> main_topics { get; set; }
        public int projects_presented { get; set; }
    }
}
