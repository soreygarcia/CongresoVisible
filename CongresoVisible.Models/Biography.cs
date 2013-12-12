using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Models
{
    public class Biography
    {
        public string professional_experience { get; set; }
        public string born_date { get; set; }
        public List<string> supported_topics { get; set; }
    }
}
