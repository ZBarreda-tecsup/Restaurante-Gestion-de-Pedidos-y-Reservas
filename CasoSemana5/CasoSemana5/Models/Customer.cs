using System;
using System.Collections.Generic;

namespace CasoSemana5.Models;

public partial class Customer
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<OrderRestaurant> OrderRestaurants { get; set; } = new List<OrderRestaurant>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
