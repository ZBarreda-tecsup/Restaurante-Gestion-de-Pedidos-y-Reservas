using System;
using System.Collections.Generic;

namespace CasoSemana5.Models;

public partial class InventoryMovement
{
    public Guid Id { get; set; }

    public Guid IngredientId { get; set; }

    public string Type { get; set; } = null!;

    public decimal Quantity { get; set; }

    public string? Reference { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Ingredient Ingredient { get; set; } = null!;
}
