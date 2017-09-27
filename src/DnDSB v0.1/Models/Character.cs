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
        public int? Alignment { get; set; }
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
        public int? ArmorWorn { get; set; }
        public int? ShieldCarried { get; set; }
        public string SpecialDefenses { get; set; }
        public string SpecialtySchool { get; set; }
        public string ChannelEnergy { get; set; }
        public string Psionics { get; set; }
        public int? ArcaneSpellFailure { get; set; }
        public int? SpellSave { get; set; }
        public int? Initiative { get; set; }

        public virtual ICollection<CharAbility> CharAbilities { get; set; }

        public int? Str { get; set; }
        public int? Dex { get { return 0; } set { } }
        public int? Con { get { return 0; } set { } }
        public int? Int { get { return 0; } set { } }
        public int? Wis { get { return 0; } set { } }
        public int? Cha { get { return 0; } set { } }


        public string StrMod { get { return GetMod(Str); } }
        public string DexMod { get { return GetMod(Dex); } }
        public string ConMod { get { return GetMod(Con); } }
        public string IntMod { get { return GetMod(Int); } }
        public string WisMod { get { return GetMod(Wis); } }
        public string ChaMod { get { return GetMod(Cha); } }


        private string GetMod(int? i)
        {
            if (i == null)
                return string.Empty;

            int mod = (int)Math.Floor((double)(i - 10) / 2);
            string modifier = Convert.ToString(mod);
            if (mod > 0) return $"+{modifier}";
            else return modifier;
        }

    }
}
