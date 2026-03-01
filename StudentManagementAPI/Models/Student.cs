using System;
using System.Collections.Generic;

namespace StudentManagementAPI.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public int? Age { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
