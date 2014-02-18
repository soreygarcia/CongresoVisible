using SQLite.Net.Attributes;
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
        [Ignore]
        public Image images { get; set; }
        public string web_url { get; set; }
        [PrimaryKey]
        public int list_number { get; set; }
        public string candidate_for { get; set; }
        public string gender { get; set; }
        [Ignore]
        public Party party { get; set; }
        [Ignore]
        public List<string> investigations { get; set; }
        [Ignore]
        public Biography biography { get; set; }
        [Ignore]
        public List<Topic> topics_positions { get; set; }
        [Ignore]
        public Trajectory trajectory { get; set; }

        //Just for database
        public string photo { get; set; }
        public string party_name { get; set; }
    }
}
