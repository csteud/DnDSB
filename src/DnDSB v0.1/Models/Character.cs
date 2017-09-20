using System;
using System.Collections.Generic;

namespace DnDSB.Models
{
    public partial class Character : CharacterBase
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public string PlayerId { get; set; }
    }
}
