using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Models
{
    public class Person
    {
        public string url { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public Image images { get; set; }
        public string web_url { get; set; }
        public int list_number { get; set; }
        public string candidate_for { get; set; }
        public string gender { get; set; }
        public Party party { get; set; }
        public List<Investigation> investigations { get; set; }
        public Biography biography { get; set; }
        public List<Topic> topics_positions { get; set; }
        public Trajectory trajectory { get; set; }
    }
}
