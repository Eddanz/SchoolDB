using Microsoft.Identity.Client;
using SchoolDB_Labb3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDB_Labb3
{
    internal class EmployeeMethods
    {
        public static void AddEmployee()
        {
            Console.Clear();
            using SchoolDbContext db = new SchoolDbContext();

            Console.Write("\nVad heter den nya anställda? (För- och efternamn)" +
                "\nMata in: ");

            var name = Console.ReadLine();

            while (true)
            {
                Console.Write($"\nVad har {name} för personnummer?" +
                $"\nMata in: ");

                if (long.TryParse(Console.ReadLine(), out long securityNumber))
                {
                    
                    Console.Write($"\nVad har {name} för roll på skolan?" +
                    $"\nMata in: ");

                    var role = Console.ReadLine();

                    Employee employee = new Employee()
                    {
                        Name = name,
                        SecurityNumber = securityNumber,
                        Role = role
                    };

                    db.Employees.Add(employee);
                    db.SaveChanges();

                    Console.WriteLine($"\nDen nyanställda {employee.Name} (ID: {employee.EmployeeId}) med roll som {employee.Role} och personnummer: {employee.SecurityNumber} har sparats!");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("\nFelaktigt personnummer, försök igen");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
            }
        }

        public static void GetEmployees()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("\n[1] Hämta all personal" +
                    "\n[2] Hämta personal som är lärare" +
                    "\n\nSkriv in ditt val: ");

                var employeeChoice = Console.ReadLine();
                switch (employeeChoice)
                {
                    case "1":
                        GetAllEmployees();
                        break;

                    case "2":
                        GetTeachers();
                        break;

                    default:
                        Console.WriteLine("\nDu måste välja mellan 1-2");
                        Console.ReadLine();
                        continue;
                }
                break;
            }
        }

        public static void GetAllEmployees()
        {
            Console.Clear();

            using SchoolDbContext db = new SchoolDbContext();

            var employees = from emp in db.Employees
                            orderby emp.Name
                            select emp;

            Console.WriteLine("\nAll personal på skolan: ");

            foreach (var employee in employees)
            {
                Console.WriteLine($"\n{employee.Name}, {employee.Role}");
            }

            Console.ReadLine();
        }

        public static void GetTeachers()
        {
            Console.Clear();

            using SchoolDbContext db = new SchoolDbContext();

            var teachers = from emp in db.Employees
                          where emp.Role == "Teacher"
                          orderby emp.Name
                          select emp;

            Console.WriteLine("\nAlla lärare på skolan: ");

            foreach (var teacher in teachers)
            {
                Console.WriteLine($"\n{teacher.Name}");
            }

            Console.ReadLine();
        }
    }
}
