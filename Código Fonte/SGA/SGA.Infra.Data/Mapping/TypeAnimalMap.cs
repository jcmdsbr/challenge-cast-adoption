using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGA.Domain.Entities.Models;

namespace SGA.Infra.Repository.Mapping
{
    internal class TypeAnimalMap : IEntityTypeConfiguration<TypeAnimal>
    {
        public void Configure(EntityTypeBuilder<TypeAnimal> builder)
        {
            builder.ToTable("tipo_animal", "dbo");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                .HasColumnName("cd_tipo_animal");

            builder.Property(c => c.Description)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}