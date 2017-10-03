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
            if (context.Characters.Any())
            {
                return;   // DB has been seeded
            }

            var characters = new Character[]
            {
            new Character{ID=0,Name="Abhire",CurrentHP=17,Con=20,Int=20,Wis=20,Cha=20,Initiative=20},
            new Character{ID=0,Name="Test",CurrentHP=17,Con=10,Int=10,Wis=10,Cha=10,Initiative=20}
            };
            foreach (Character s in characters)
            {
                context.Characters.Add(s);
            }
            context.SaveChanges();
        }
    }
}