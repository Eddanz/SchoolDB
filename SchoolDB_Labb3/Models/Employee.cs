using System;
using System.Collections.Generic;

namespace SchoolDB_Labb3.Models;

public partial class Employee
{
    public short EmployeeId { get; set; }

    public long SecurityNumber { get; set; }

    public string FullName { get; set; } = null!;

    public string? Department { get; set; }

    public decimal? Salary { get; set; }

    public DateOnly? StartDate { get; set; }
}
