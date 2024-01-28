using System;
using System.Collections.Generic;

namespace SchoolDB_Labb3.Models;

public partial class Course
{
    public short CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public short? FkEmployeeId { get; set; }

    public virtual Employee? FkEmployee { get; set; }
}
