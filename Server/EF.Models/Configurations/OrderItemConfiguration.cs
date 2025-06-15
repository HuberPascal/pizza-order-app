using EF.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.Models.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.Property(oi => oi.UnitPrice)
            .HasPrecision(10, 2);

        builder.Property(oi => oi.SpecialInstructions)
            .HasMaxLength(500);

        builder.HasMany(oi => oi.ExtraToppings)
            .WithMany(et => et.OrderItems);
    }
}