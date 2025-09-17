using System;
using System.Collections.Generic;

namespace CasoSemana5.Models;

public partial class OrderRestaurant
{
    public Guid Id { get; set; }

    public Guid? TableId { get; set; }

    public Guid? ReservationId { get; set; }

    public Guid? CustomerId { get; set; }

    public string? Status { get; set; }

    public string? Channel { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Reservation? Reservation { get; set; }

    public virtual TableRestaurant? Table { get; set; }
}
