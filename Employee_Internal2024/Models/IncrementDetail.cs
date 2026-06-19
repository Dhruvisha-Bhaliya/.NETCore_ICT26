using System;
using System.Collections.Generic;

namespace Employee_Internal2024.Models;

public partial class IncrementDetail
{
    public int IncrementId { get; set; }

    public int? EmployeeId { get; set; }

    public decimal? BasicSalary { get; set; }

    public decimal? Increment { get; set; }

    public decimal? NewBasicSalary { get; set; }

    public virtual Employee? Employee { get; set; }
}
