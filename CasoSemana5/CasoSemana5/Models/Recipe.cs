using System;
using System.Collections.Generic;

namespace CasoSemana5.Models;

public partial class Recipe
{
    public Guid Id { get; set; }

    public Guid MenuItemId { get; set; }

    public Guid IngredientId { get; set; }

    public decimal Quantity { get; set; }

    public string Unit { get; set; } = null!;

    public virtual Ingredient Ingredient { get; set; } = null!;

    public virtual MenuItem MenuItem { get; set; } = null!;
}
