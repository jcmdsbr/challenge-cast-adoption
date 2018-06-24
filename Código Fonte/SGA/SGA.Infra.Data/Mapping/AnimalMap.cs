using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGA.Domain.Entities.Models;

namespace SGA.Infra.Repository.Mapping
{
    internal class AnimalMap : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.ToTable("animal", "dbo");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("cd_animal");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(10)")
                .HasColumnName("nm_animal")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasColumnType("varchar(100)")
                .HasColumnName("dc_animal")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.TypeAnimalId)
                .HasColumnName("cd_tipo_animal");


            builder.HasOne(s => s.TypeAnimal)
                .WithMany()
                .HasForeignKey(e => e.TypeAnimalId)
                .IsRequired();
        }
    }
}