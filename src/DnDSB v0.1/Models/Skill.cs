using System;
using System.Collections.Generic;

namespace DnDSB
{
    public partial class Skill
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Subtype { get; set; }
        public string Key_ability { get; set; }
        public int AbilityScoreID { get; set; }
        public string Psionic { get; set; }
        public string Trained { get; set; }
        public string Armor_check { get; set; }
        public string Description { get; set; }
        public string Skill_check { get; set; }
        public string Action { get; set; }
        public string Try_again { get; set; }
        public string Special { get; set; }
        public string Restriction { get; set; }
        public string Synergy { get; set; }
        public string Epic_use { get; set; }
        public string Untrained { get; set; }
        public string Full_text { get; set; }
        public string Reference { get; set; }

        public string GetSubType(int i)
        {
            List<string> Subtypes = new List<string>();
            string[] split = Subtype.Split(',');
            foreach (string s in split)
                Subtypes.Add(s);

            if (Subtypes.Count < i-1) 
                return string.Empty;
            return Subtypes[i-1];
        }
        public virtual AbilityScore AbilityScore { get; set; }
    }
}
