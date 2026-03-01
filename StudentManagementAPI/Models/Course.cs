using System;
using System.Collections.Generic;

namespace StudentManagementAPI.Models;

public partial class Course
{
    public int Id { get; set; }

    public string? CourseName { get; set; }

    public string? Duration { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
