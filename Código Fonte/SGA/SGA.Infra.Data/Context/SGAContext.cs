using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SGA.Domain.Entities.Models;
using SGA.Infra.Repository.Mapping;

namespace SGA.Infra.Repository.Context
{
    public sealed class SgaContext : DbContext
    {
        public SgaContext()
        {
            Database.EnsureCreated(); // create a db -f
        }

        public DbSet<Pet> Animals { get; set; }
        public DbSet<TypePet> TypeAnimals { get; set; }
        public DbSet<Responsible> Responsibles { get; set; }
        public DbSet<Adoption> Adoptions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TypePetMap());
            modelBuilder.ApplyConfiguration(new PetMap());
            modelBuilder.ApplyConfiguration(new ResponsibleMap());
            modelBuilder.ApplyConfiguration(new AdoptionMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}