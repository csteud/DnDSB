using DnDSB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnDSB
{
    

    public partial class CharWeapon
    {
        public int? ID { get; set; }        
        public int? CharacterID { get; set; }
        public string Name { get; set; }
        public string ATK { get; set; }
        public string DMG { get; set; }
        public string CRIT { get; set; }
        public string RNG { get; set; }
        public string TYP { get; set; }
        public string AMMO { get; set; }
        public string Notes { get; set; }    

     
        public virtual Character Character { get; set; }

      
    }
}
