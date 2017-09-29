using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDSB.Models
{
    public class Race
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abbrv { get; set; }
        public string Description { get; set; }
        public string Personality { get; set; }
        public string PhysicalDescription { get; set; }
        public string Relations { get; set; }
        public string Alignment { get; set; }
        public string Lands { get; set; }
        public string Religion { get; set; }
        public string Language { get; set; }
        public string Names { get; set; }
        public string Adventurers { get; set; }
        public string Size { get; set; }

        public virtual Character Character { get; set; }

    }
}
