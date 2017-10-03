using System;
using System.Collections.Generic;

namespace DnDSB.Models
{
    public enum Sex { M, F };
    public partial class Character
    {
        public int ID { get; set; }
        public int PlayerID { get; set; }
        //public int CampaignID {get;set;}
        public string Name { get; set; }
        public int? Age { get; set; }
        public int? RaceID { get; set; }
        public string Gender { get; set; }
        public int? AlignmentID { get; set; }
        public string Religion { get; set; }
        public int? Height01 { get; set; }
        public int? Height02 { get; set; }
        public int? Weight { get; set; }
        public string Hair { get; set; }
        public string Eyes { get; set; }
        public string Misc { get; set; }
        public int? HitDie { get; set; }
        public int? MaxHP { get; set; }
        public int? CurrentHP { get; set; }
        public int? BAB { get; set; }
        public string Equip01 { get; set; }
        public string Equip02 { get; set; }
        public string Equip03 { get; set; }
        public string Buffs { get; set; }
        public int? InitiativeMod { get; set; }
        public int? InitiativeModDisplay { get { return InitiativeMod + Dex; } }
        public int? ArmorWorn { get; set; }
        public int? ShieldCarried { get; set; }
        public string SpecialDefenses { get; set; }
        public string SpecialtySchool { get; set; }
        public string ChannelEnergy { get; set; }
        public string Psionics { get; set; }
        public int? ArcaneSpellFailure { get; set; }
        public int? SpellSave { get; set; }
        public int? Initiative { get; set; }
        public int? Speed { get; set; }
        public int? SizeMod { get { return SizeModConverter.ConvertToMod(Race.Size); } }
        public int? GrappleMod { get { return BAB + Str + SizeMod + MiscGrappleMod; } }
        public int? MiscGrappleMod { get; set; } = 0;

        public int? AC
        {
            get { return 10+ArmorAC + ShieldAC + Dex + SizeMod + ArmorNatural + ArmorDeflection + ArmorMisc; }
        }
        public string ArmorName { get; set; }
        public string ShieldName { get; set; }
        public int? ArmorMaxDex { get; set; }
        public int? ArmorCheckPenalty { get; set; }
        public int? ArmorWeight { get; set; }
        public int? ArmorAC { get; set; }
        public int? ShieldAC { get; set; }
        public int? ArmorNatural { get; set; }
        public int? ArmorDeflection { get; set; }
        public int? ArmorMisc { get; set; }
        public int? ShieldMaxDex { get; set; }
        public int? ShieldArmorCheckPenalty { get; set; }
        public int? ShieldWeight { get; set; }

                
        public virtual ICollection<CharAbility> CharAbilities { get; set; }
        //public List<CharSkill> Skills
        //{
        //    get
        //    {
        //        List<CharSkill> _skill = new List<CharSkill>();
        //        foreach (var skill in CharSkills)
        //            _skill.Add(skill);
        //        _skill.Sort((x,y) => string.Compare(x.Skill.Name,y.Skill.Name));
        //        return _skill;
        //    }
        //}
        public virtual ICollection<CharSkill> CharSkills { get; set; }
        public virtual ICollection<CharSave> CharSaves { get; set; }
        public virtual ICollection<CharWeapon> CharWeapons { get; set; }
        public virtual Race Race { get; set; }
        public virtual Alignment Alignment { get; set; }
        public ICollection<CharClass> CharClass { get; set; }
        public int? ECL { get { return GetECL(); } }

        public int? Str
        {
            get
            {
                foreach (var item in CharAbilities)
                {
                    if (item.AbilityScore.ShortName == "STR")
                        return GetMod(item.Value);
                }
                return 0;
            }
        }
        public int? Dex
        {
            get
            {
                foreach (var item in CharAbilities)
                {
                    if (item.AbilityScore.ShortName == "DEX")
                        return GetMod(item.Value);
                }
                return 0;
            }
        }
        public int? Con { get { return 0; } set { } }
        public int? Int { get { return 0; } set { } }
        public int? Wis { get { return 0; } set { } }
        public int? Cha { get { return 0; } set { } }

        private int? GetECL()
        {
            int? total = 0;

            foreach(var c in CharClass)
            {
                total += c.Levels;
            }

            return total;
        }

        private int? GetMod(int? i)
        {
            if (i == null)
                return null;

            int mod = (int)Math.Floor((double)(i - 10) / 2);
            return mod;
        }
    }
}
