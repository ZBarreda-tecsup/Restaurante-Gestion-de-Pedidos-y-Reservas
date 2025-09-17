using System;
using System.Collections.Generic;

namespace CasoSemana5.Models;

public partial class MenuItem
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Category { get; set; }

    public decimal Price { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
