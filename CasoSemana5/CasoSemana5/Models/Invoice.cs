using System;
using System.Collections.Generic;

namespace CasoSemana5.Models;

public partial class Invoice
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public decimal Subtotal { get; set; }

    public decimal? Taxes { get; set; }

    public decimal? Discounts { get; set; }

    public decimal Total { get; set; }

    public string? Currency { get; set; }

    public string? PdfUrl { get; set; }

    public string? XmlUrl { get; set; }

    public string? Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual OrderRestaurant Order { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
