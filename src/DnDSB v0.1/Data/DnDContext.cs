using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DnDSB.Models
{
    public class DnDContext : DbContext
    {
        public DnDContext(DbContextOptions<DnDContext> options) : base(options)
        {

        }


        public DbSet<Character> Character { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().ToTable("Character");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Character>(entity =>
        //    {
        //        entity.Property(e => e.CharacterId)
        //            .HasColumnName("CharacterID")
        //            .ValueGeneratedNever();

        //        entity.Property(e => e.Cha).HasColumnName("CHA");

        //        entity.Property(e => e.CharacterName).HasColumnType("varchar(50)");

        //        entity.Property(e => e.Con).HasColumnName("CON");

        //        entity.Property(e => e.Dex).HasColumnName("DEX");

        //        entity.Property(e => e.Hp).HasColumnName("HP");

        //        entity.Property(e => e.Int).HasColumnName("INT");

        //        entity.Property(e => e.Str).HasColumnName("STR");

        //        entity.Property(e => e.Wis).HasColumnName("WIS");
        //    });
        //}
    }
}