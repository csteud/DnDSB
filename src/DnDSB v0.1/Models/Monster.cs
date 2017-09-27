using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDSB
{
    public class Monster : CharacterBase
    {
        public int MonsterId { get; set; }
        public string MonsterName { get; set; }
        public string MonsterShortDescription { get; set; }
    }
}
