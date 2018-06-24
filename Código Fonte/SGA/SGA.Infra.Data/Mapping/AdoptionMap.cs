using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGA.Domain.Entities.Models;

namespace SGA.Infra.Repository.Mapping
{
    internal class AdoptionMap : IEntityTypeConfiguration<Adoption>
    {
        public void Configure(EntityTypeBuilder<Adoption> builder)
        {
            builder.ToTable("adocao", "dbo");

            builder.HasKey(c => new {c.ResponsibleId, c.AnimalId});

            builder.HasAlternateKey(c => c.AnimalId)
                .HasName("animal_unique");

            builder.Property(f => f.AnimalId)
                .HasColumnName("cd_animal");


            builder.Property(f => f.ResponsibleId)
                .HasColumnName("cd_responsavel");

            builder.Property(c => c.DateAdoption)
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(s => s.Responsible)
                .WithMany()
                .HasForeignKey(e => e.ResponsibleId)
                .IsRequired();

            builder.HasOne(s => s.Animal)
                .WithMany()
                .HasForeignKey(e => e.AnimalId)
                .IsRequired();
        }
    }
}