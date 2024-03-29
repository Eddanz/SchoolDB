﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolDB_Labb3.Models;

#nullable disable

namespace SchoolDB_Labb3.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    partial class SchoolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SchoolDB_Labb3.Models.Course", b =>
                {
                    b.Property<short>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("CourseID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("CourseId"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Course_Name");

                    b.Property<short?>("FkEmployeeId")
                        .HasColumnType("smallint")
                        .HasColumnName("FK_EmployeeID");

                    b.HasKey("CourseId");

                    b.HasIndex("FkEmployeeId");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("SchoolDB_Labb3.Models.Employee", b =>
                {
                    b.Property<short>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("EmployeeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("EmployeeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Role")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<long>("SecurityNumber")
                        .HasColumnType("bigint")
                        .HasColumnName("Security_Number");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("SchoolDB_Labb3.Models.Grade", b =>
                {
                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<short>("FkCourseId")
                        .HasColumnType("smallint")
                        .HasColumnName("FK_CourseID");

                    b.Property<short>("FkEmployeeId")
                        .HasColumnType("smallint")
                        .HasColumnName("FK_EmployeeID");

                    b.Property<short>("FkStudentId")
                        .HasColumnType("smallint")
                        .HasColumnName("FK_StudentID");

                    b.Property<string>("Grade1")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("Grade");

                    b.HasIndex("FkCourseId");

                    b.HasIndex("FkEmployeeId");

                    b.HasIndex("FkStudentId");

                    b.ToTable("Grade", (string)null);
                });

            modelBuilder.Entity("SchoolDB_Labb3.Models.Student", b =>
                {
                    b.Property<short>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("StudentID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("StudentId"));

                    b.Property<string>("Class")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<long>("SecurityNumber")
                        .HasColumnType("bigint")
                        .HasColumnName("Security_Number");

                    b.HasKey("StudentId");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("SchoolDB_Labb3.Models.Course", b =>
                {
                    b.HasOne("SchoolDB_Labb3.Models.Employee", "FkEmployee")
                        .WithMany("Courses")
                        .HasForeignKey("FkEmployeeId")
                        .HasConstraintName("FK_Course_Employee");

                    b.Navigation("FkEmployee");
                });

            modelBuilder.Entity("SchoolDB_Labb3.Models.Grade", b =>
                {
                    b.HasOne("SchoolDB_Labb3.Models.Course", "FkCourse")
                        .WithMany()
                        .HasForeignKey("FkCourseId")
                        .IsRequired()
                        .HasConstraintName("FK_Grade_Course");

                    b.HasOne("SchoolDB_Labb3.Models.Employee", "FkEmployee")
                        .WithMany()
                        .HasForeignKey("FkEmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK_Grade_Employee");

                    b.HasOne("SchoolDB_Labb3.Models.Student", "FkStudent")
                        .WithMany()
                        .HasForeignKey("FkStudentId")
                        .IsRequired()
                        .HasConstraintName("FK_Grade_Student");

                    b.Navigation("FkCourse");

                    b.Navigation("FkEmployee");

                    b.Navigation("FkStudent");
                });

            modelBuilder.Entity("SchoolDB_Labb3.Models.Employee", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
