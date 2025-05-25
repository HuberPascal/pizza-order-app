using EF.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EF.Models;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Order> Orders { get; set; }
    DbSet<OrderItem> OrderItems { get; set; }
    DbSet<Pizza> Pizzas { get; set; }
    DbSet<ExtraTopping> ExtraToppings { get; set; }
}