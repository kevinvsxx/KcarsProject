using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Data
{
    public class EFContext : IdentityDbContext
    { 
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Bestelling> Bestellingen { get; set; }
        public DbSet<Artikel> Artikels { get; set; }
        public DbSet<BestellingArtikel> BestellingArtikels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Klant>().ToTable("Klant");
            modelBuilder.Entity<Bestelling>().ToTable("Bestelling");
            modelBuilder.Entity<Artikel>().ToTable("Artikel");
            modelBuilder.Entity<BestellingArtikel>().ToTable("BestellingArtikel");
        }
    }
}
