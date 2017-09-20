using System;
using System.Collections.Generic;

namespace DnDSB.Models
{
    public partial class Character
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public int? Hp { get; set; }
        public int? Str { get; set; }
        public int? Dex { get; set; }
        public int? Con { get; set; }
        public int? Int { get; set; }
        public int? Wis { get; set; }
        public int? Cha { get; set; }
        public int? Initiative { get; set; }
    }
}
