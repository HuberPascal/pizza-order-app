using System;

namespace EF.Models.Models;

public class Pizza
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Ingredients { get; set; }
}