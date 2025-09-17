using System;
using System.Collections.Generic;

namespace CasoSemana5.Models;

public partial class Payment
{
    public Guid Id { get; set; }

    public Guid InvoiceId { get; set; }

    public string Method { get; set; } = null!;

    public decimal Amount { get; set; }

    public string? Status { get; set; }

    public string? AuthorizationCode { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;
}
