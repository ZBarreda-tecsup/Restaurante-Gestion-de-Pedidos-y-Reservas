using System;
using System.Collections.Generic;

namespace CasoSemana5.Models;

public partial class Branch
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Timezone { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<TableRestaurant> TableRestaurants { get; set; } = new List<TableRestaurant>();
}
