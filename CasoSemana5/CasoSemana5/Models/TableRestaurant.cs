using System;
using System.Collections.Generic;

namespace CasoSemana5.Models;

public partial class TableRestaurant
{
    public Guid Id { get; set; }

    public Guid BranchId { get; set; }

    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    public string? Status { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual ICollection<OrderRestaurant> OrderRestaurants { get; set; } = new List<OrderRestaurant>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
