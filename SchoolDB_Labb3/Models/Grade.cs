using System;
using System.Collections.Generic;

namespace SchoolDB_Labb3.Models;

public partial class Grade
{
    public string Grade1 { get; set; } = null!;

    public DateOnly Date { get; set; }

    public short FkCourseId { get; set; }

    public short FkStudentId { get; set; }

    public short FkEmployeeId { get; set; }

    public virtual Course FkCourse { get; set; } = null!;

    public virtual Employee FkEmployee { get; set; } = null!;

    public virtual Student FkStudent { get; set; } = null!;
}
