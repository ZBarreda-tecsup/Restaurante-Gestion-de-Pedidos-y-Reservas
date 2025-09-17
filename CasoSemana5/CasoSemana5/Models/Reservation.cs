using System;
using System.Collections.Generic;

namespace CasoSemana5.Models;

public partial class Reservation
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public Guid BranchId { get; set; }

    public Guid TableId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int Guests { get; set; }

    public string? Status { get; set; }

    public string? RecurrenceRule { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderRestaurant> OrderRestaurants { get; set; } = new List<OrderRestaurant>();

    public virtual TableRestaurant Table { get; set; } = null!;
}
