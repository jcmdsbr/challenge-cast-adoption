using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities.Models;
using SGA.Infra.Repository.Mapping;

namespace SGA.Infra.Repository.Context
{
    public sealed class SgaContext : DbContext
    {
        public SgaContext(DbContextOptions<SgaContext> options) : base(options)
        {
        }

        public DbSet<Pet> Animals { get; set; }
        public DbSet<TypePet> TypeAnimals { get; set; }
        public DbSet<Responsible> Responsibles { get; set; }
        public DbSet<Adoption> Adoptions { get; set; }

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