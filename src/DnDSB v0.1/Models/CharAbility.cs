using DnDSB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnDSB
{
    public partial class AbilityScore
    {
        public int? ID { get; set; }
        public string Name { get; set; }
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
        public virtual int? Mod { get { return GetMod(Total); } }
        public virtual string ModDisplay { get { return GetModDisplay(GetMod(Total)); } }

        private int? GetMod(int? i)
        {
            if (i == null)
                return null;

            int mod = (int)Math.Floor((double)(i - 10) / 2);
            return mod;
        }

        private string GetModDisplay(int? i)
        {
            if (i == null)
                return null;                       
            string modifier = Convert.ToString(i);
            if (i > 0) return $"+{modifier}";
            else return modifier;
        }
    }

    public partial class CharSave
    {
        public int? ID { get; set; }
        public int? AbilityScoreID { get; set; }
        public int? CharacterID { get; set; }
        public string Name { get; set; }
        public int? Base { get; set; }
        public int? MagicMod { get; set; }
        public int? MiscMod { get; set; }
        public int? TemporaryMod { get; set; }

        public virtual AbilityScore AbilityScore { get; set; }
        public virtual Character Character { get; set; }
        public virtual int? AbilityMod
        {
            get
            {
                foreach(var ability in Character.CharAbilities)
                {
                    if (ability.AbilityScore == AbilityScore)
                        return ability.Mod;
                }
                return 0;
            }
        }

        public int? Total { get { return Base + MagicMod + MiscMod + TemporaryMod + AbilityMod; } }
        
    }
}
