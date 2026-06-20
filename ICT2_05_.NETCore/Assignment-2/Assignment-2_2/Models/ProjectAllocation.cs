using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace Assignment_2_2.Models;

public partial class ProjectAllocation
{
    public int AllocationId { get; set; }

    public int EmployeeId { get; set; }

    public int ProjectId { get; set; }

    public DateOnly? AllocationDate { get; set; }

    public string? Role { get; set; }

    public bool? IsActive { get; set; }

    [ValidateNever]
    public virtual Employee Employee { get; set; } = null!;

    [ValidateNever]
    public virtual Project Project { get; set; } = null!;
}
