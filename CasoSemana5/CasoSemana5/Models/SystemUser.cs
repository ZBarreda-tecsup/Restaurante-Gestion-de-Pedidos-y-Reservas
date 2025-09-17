using System;
using System.Collections.Generic;

namespace CasoSemana5.Models;

public partial class SystemUser
{
    public Guid Id { get; set; }

    public string Role { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;
}
