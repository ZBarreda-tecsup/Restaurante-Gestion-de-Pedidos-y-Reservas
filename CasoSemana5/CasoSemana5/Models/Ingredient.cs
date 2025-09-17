using System;
using System.Collections.Generic;

namespace CasoSemana5.Models;

public partial class Ingredient
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Unit { get; set; } = null!;

    public decimal? Stock { get; set; }

    public decimal? MinStock { get; set; }

    public virtual ICollection<InventoryMovement> InventoryMovements { get; set; } = new List<InventoryMovement>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
