using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Models
{
    public class Filter
    {
        public string name { get; set; }
        public string key { get; set; }
        public string value { get; set; }
        public bool selected { get; set; }
    }
}
