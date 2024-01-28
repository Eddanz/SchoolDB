using System;
using System.Collections.Generic;

namespace SchoolDB_Labb3.Models;

public partial class Employee
{
    public short EmployeeId { get; set; }

    public long SecurityNumber { get; set; }

    public string Name { get; set; } = null!;

    public string? Role { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
