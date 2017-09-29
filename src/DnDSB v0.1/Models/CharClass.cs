using System;
using System.Collections.Generic;

namespace DnDSB.Models
{
    public partial class CharClass
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int ClassId { get; set; }
        public int? Levels { get; set; }

        public virtual Character Character { get; set; }
        public virtual Class Class { get; set; }

    }
}
