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
        public DbSet<Auto> Autos { get; set; }
        public DbSet<Piloot> Piloots { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Circuit> Circuits { get; set; }
        public DbSet<AutoRace> AutoRaces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Auto>().ToTable("Auto");
            modelBuilder.Entity<Piloot>().ToTable("Piloot");
            modelBuilder.Entity<Race>().ToTable("Race");
            modelBuilder.Entity<Circuit>().ToTable("Circuit");
            modelBuilder.Entity<AutoRace>().ToTable("AutoRace");
        }
    }
}
