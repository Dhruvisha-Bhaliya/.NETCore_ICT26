using System;
using System.Collections.Generic;

namespace MVC_Registration.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
}
