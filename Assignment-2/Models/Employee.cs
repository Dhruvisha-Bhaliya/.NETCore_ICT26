using System;
using System.Collections.Generic;

namespace Assignment_2.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string? Email { get; set; }

    public string? Department { get; set; }

    public DateOnly? JoiningDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<ProjectAllocation> ProjectAllocations { get; set; } = new List<ProjectAllocation>();
}
