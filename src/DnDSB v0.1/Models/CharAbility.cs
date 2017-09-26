using DnDSB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnDSB
{
    public partial class AbilityScore
    {
        public int? ID { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string AppliesTo { get; set; }

        public virtual ICollection<CharAbility> CharAbilities { get; set; }
    }

    public partial class CharAbility
    {
        public int? ID { get; set; }
        public int? AbilityScoreID { get; set; }
        public int? CharacterID { get; set; }
        public int? Value { get; set; }
        public int? Enhancement { get; set; }
        public int? MiscBonus { get; set; }
        public int? MiscBonus2 { get; set; }
        public int? MiscPenalties { get; set; }

        public virtual AbilityScore AbilityScore { get; set; }
        public virtual Character Character { get; set; }

        public int? Total { get { return Value + Enhancement + MiscBonus + MiscBonus2 + MiscPenalties; } }
        public virtual string Mod { get { return GetMod(Total); } }

        private string GetMod(int? i)
        {
            if (i == null)
                return null;

            int mod = (int)Math.Floor((double)(i - 10) / 2);
            string modifier = Convert.ToString(mod);
            if (mod > 0) return $"+{modifier}";
            else return modifier;
        }
    }
}
