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

            builder.HasKey(c => new {c.ResponsibleId, AnimalId = c.PetId});

            builder.HasAlternateKey(c => c.PetId)
                .HasName("animal_unique");

            builder.Property(f => f.PetId)
                .HasColumnName("cd_animal");


            builder.Property(f => f.ResponsibleId)
                .HasColumnName("cd_responsavel");

            builder.Property(c => c.DateAdoption)
                .HasColumnName("dt_adocao")
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");


            builder.HasOne(s => s.Responsible)
                .WithMany()
                .HasForeignKey(e => e.ResponsibleId)
                .IsRequired();

            builder.HasOne(s => s.Pet)
                .WithMany()
                .HasForeignKey(e => e.PetId)
                .IsRequired();
        }
    }
}