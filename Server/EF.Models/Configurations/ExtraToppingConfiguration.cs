using EF.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.Models.Configurations;

public class ExtraToppingConfiguration : IEntityTypeConfiguration<ExtraTopping>
{
    public void Configure(EntityTypeBuilder<ExtraTopping> builder)
    {
        builder.Property(et => et.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(et => et.Description)
            .HasMaxLength(500);

        builder.Property(et => et.Price)
            .HasPrecision(10, 2);
    }
}