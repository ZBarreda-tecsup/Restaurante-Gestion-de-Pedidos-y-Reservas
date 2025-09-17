using System;
using System.Collections.Generic;

namespace CasoSemana5.Models;

public partial class OrderItem
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public Guid MenuItemId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public string? Notes { get; set; }

    public string? Status { get; set; }

    public virtual MenuItem MenuItem { get; set; } = null!;

    public virtual OrderRestaurant Order { get; set; } = null!;
}
