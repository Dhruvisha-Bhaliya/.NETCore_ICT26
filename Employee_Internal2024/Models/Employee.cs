using System;
using System.Collections.Generic;

namespace Employee_Internal2024.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public int? Designation { get; set; }

    public virtual ICollection<IncrementDetail> IncrementDetails { get; set; } = new List<IncrementDetail>();
}
