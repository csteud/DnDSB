using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDSB
{
    public class CharacterBase
    {
       
        public int? Hp { get; set; }
        public int? MaxHp { get; set; }
        public int? Str { get; set; }
        public int? Dex { get; set; }
        public int? Con { get; set; }
        public int? Int { get; set; }
        public int? Wis { get; set; }
        public int? Cha { get; set; }
        public int? Initiative { get; set; }

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
