using System;
using System.Collections.Generic;

namespace SchoolDB_Labb3.Models;

public partial class Student
{
    public short StudentId { get; set; }

    public long SecurityNumber { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? Class { get; set; }
}
