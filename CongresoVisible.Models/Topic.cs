using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Models
{
    public class Topic
    {
        public string posicion { get; set; }
        [PrimaryKey]
        public string name { get; set; }
    }
}
