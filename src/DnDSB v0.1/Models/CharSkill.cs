using DnDSB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnDSB
{
   

    public partial class CharSkill
    {
        public int? ID { get; set; }
        public int? CharacterID { get; set; }
        public int? SkillID { get; set; }
        public int? Ranks { get; set; }
        public int? MiscModifier { get; set; }       
        public int? Subskill { get; set; }

        public virtual Skill Skill { get; set; }
        public virtual Character Character { get; set; }

        public int? Total { get { return AbilityMod + Ranks + MiscModifier; } }
        public int? AbilityMod
        {
            get
            {
                foreach (var ability in Character.CharAbilities)
                    if (ability.AbilityScore == Skill.AbilityScore)
                        return ability.Mod;
                return 0;
            }
            
        }
        public string GetSubSkill
        {
            get
            {
                if (Subskill == null)
                    return string.Empty;
                return Skill.GetSubType((int)Subskill);
            }
        }

      //  public int? Total { get { return Value + Enhancement + MiscBonus + MiscBonus2 + MiscPenalties; } }
     
      
    }

    
}
