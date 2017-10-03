using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnDSB.Models
{
    public enum SizeMod
    {
       Fine = 8,
        Diminutive = 4,
        Tiny = 2,
        Small = 1,
        Medium = 0,
        Large = -1,
        Huge = -2,
        Gargantuan = -4,
        Colossal = -8,
    };
    public static class SizeModConverter
    {
        public static int ConvertToMod(string s)
        {
            switch(s)
            {
                case "Fine":return (int)SizeMod.Fine;
                case "Diminutive": return (int)SizeMod.Diminutive;
                case "Tiny": return (int)SizeMod.Tiny;
                case "Small": return (int)SizeMod.Small;
                case "Medium": return (int)SizeMod.Medium;
                case "Large": return (int)SizeMod.Large;
                case "Huge": return (int)SizeMod.Huge;
                case "Gargantuan": return (int)SizeMod.Gargantuan;
                case "Colossal": return (int)SizeMod.Colossal;
                default: return 0;
            }           
        }
    }
    public class Race
    {
       
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abbrv { get; set; }
        public string Description { get; set; }
        public string Personality { get; set; }
        public string PhysicalDescription { get; set; }
        public string Relations { get; set; }
        public string Alignment { get; set; }
        public string Lands { get; set; }
        public string Religion { get; set; }
        public string Language { get; set; }
        public string Names { get; set; }
        public string Adventurers { get; set; }
        public string Size { get; set; }
        
        public virtual Character Character { get; set; }

    }
}
