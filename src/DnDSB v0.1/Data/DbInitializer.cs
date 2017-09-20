using DnDSB.Models;
using System;
using System.Linq;

namespace DnDSB.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DnDContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Character.Any())
            {
                return;   // DB has been seeded
            }

            var characters = new Character[]
            {
            new Character{CharacterId=0,CharacterName="Abhire",Hp=17,Str=17,Dex=20,Con=20,Int=20,Wis=20,Cha=20,Initiative=20},
            new Character{CharacterId=0,CharacterName="Test",Hp=17,Str=17,Dex=10,Con=10,Int=10,Wis=10,Cha=10,Initiative=20}
            };
            foreach (Character s in characters)
            {
                context.Character.Add(s);
            }
            context.SaveChanges();
        }
    }
}