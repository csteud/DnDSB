using System;
using System.Collections.Generic;

namespace DnDSB.Models
{
    public partial class Alignment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }

        public Character Character { get; set; }
    }
}
