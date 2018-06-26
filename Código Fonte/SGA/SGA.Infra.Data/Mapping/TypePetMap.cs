using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGA.Domain.Entities.Models;

namespace SGA.Infra.Repository.Mapping
{
    internal class TypePetMap : IEntityTypeConfiguration<TypePet>
    {
        public void Configure(EntityTypeBuilder<TypePet> builder)
        {
            builder.ToTable("tipo_animal", "dbo");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                .HasColumnName("cd_tipo_animal");

            builder.Property(c => c.Description)
                .HasColumnName("dc_tipo_animal")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}