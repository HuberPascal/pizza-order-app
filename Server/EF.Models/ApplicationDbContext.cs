using EF.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EF.Models;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<ExtraTopping> ExtraToppings { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Orders)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<OrderItem>()
            .HasMany(oi => oi.ExtraToppings)
            .WithMany(et => et.OrderItems);
        
        modelBuilder.Entity<Pizza>()
            .Property(p => p.Price)
            .HasPrecision(10, 2);

        modelBuilder.Entity<OrderItem>()
            .Property(oi => oi.UnitPrice)
            .HasPrecision(10, 2);

        modelBuilder.Entity<Order>()
            .Property(o => o.TotalPrice)
            .HasPrecision(10, 2);
        
        modelBuilder.Entity<OrderItem>()
            .Property(oi => oi.SpecialInstructions)
            .HasMaxLength(500);
        
        modelBuilder.Entity<ExtraTopping>()
            .Property(et => et.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        modelBuilder.Entity<ExtraTopping>()
            .Property(et => et.Description)
            .HasMaxLength(500);
    }
}