using System;
using System.Collections.Generic;

namespace DnDSB.Models
{
    public partial class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Alignment { get; set; }
        public string Hit_Die { get; set; }
        public string Class_Skills { get; set; }
        public string Skill_Points { get; set; }
        public string Skill_Points_Ability { get; set; }
        public string Spell_Stat { get; set; }
        public string Proficiencies { get; set; }
        public string Spell_Type { get; set; }
        public string Epic_Feat_Base_Level { get; set; }
        public string Epic_Feat_Interval { get; set; }
        public string Epic_Feat_List { get; set; }
        public string Epic_Full_Text { get; set; }
        public string Req_Race { get; set; }
        public string Req_Weapon_Proficiency { get; set; }
        public string Req_Base_Attack_Bonus { get; set; }
        public string Req_Skill { get; set; }
        public string Req_Feat { get; set; }
        public string Req_Spells { get; set; }
        public string Req_Languages { get; set; }
        public string Req_Psionics { get; set; }
        public string Req_Epic_Feat { get; set; }
        public string Req_Special { get; set; }
        public string Spell_List_1 { get; set; }
        public string Spell_List_2 { get; set; }
        public string Spell_List_3 { get; set; }
        public string Spell_List_4 { get; set; }
        public string Spell_List_5 { get; set; }
        public string Full_Text { get; set; }
        public string Reference { get; set; }
    }
}
