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
        public DbSet<Klant> klanten { get; set; }
        public DbSet<Bestelling> bestellingen { get; set; }
        public DbSet<Artikel> artikels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Klant>().ToTable("Klant");
            modelBuilder.Entity<Bestelling>().ToTable("Bestelling");
            modelBuilder.Entity<Artikel>().ToTable("Artikel");
        }
    }
}
