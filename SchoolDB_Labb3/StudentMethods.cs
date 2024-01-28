using SchoolDB_Labb3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDB_Labb3
{
    internal class StudentMethods
    {
        public static void GetStudents()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("\nHur vill du ha namnen sorterade?" +
                    "\n\n[1] Förnamn" +
                    "\n[2] Efternamn" +
                    "\n\nSkriv in ditt val: "
                    );

                var nameChoice = Console.ReadLine();

                switch (nameChoice)
                {
                    case "1":
                        SortByFirstName();
                        break;

                    case "2":
                        SortByLastName();
                        break;

                    default:
                        Console.WriteLine("\nDu måste välja mellan 1-2");
                        Console.ReadLine();
                        continue;
                }
                break;
            }
        }

        public static void SortByFirstName()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("\nI vilken ordning vill du ha det sorterade?" +
                            "\n\n[1] Stigande" +
                            "\n[2] Fallande" +
                            "\n\nSkriv in ditt val: ");

                var firstNameChoice = Console.ReadLine();

                switch (firstNameChoice)
                {
                    case "1":
                        FirstNameAsc();
                        break;

                    case "2":
                        FirstNameDesc();
                        break;

                    default:
                        Console.WriteLine("\nDu måste välja mellan 1-2");
                        Console.ReadLine();
                        continue;
                }
                break;
            }
        }

        public static void SortByLastName()
        {
            while(true)
            {
                Console.Clear();
                Console.Write("\nI vilken ordning vill du ha det sorterade?" +
                            "\n\n[1] Stigande" +
                            "\n[2] Fallande" +
                            "\n\nSkriv in ditt val: ");

                var lastNameChoice = Console.ReadLine();

                switch (lastNameChoice)
                {
                    case "1":
                        LastNameAsc();
                        break;

                    case "2":
                        LastNameDesc();
                        break;

                    default:
                        Console.WriteLine("\nDu måste välja mellan 1-2");
                        Console.ReadLine();
                        continue;
                }
                break;
            }
        }

        public static void FirstNameAsc()
        {
            Console.Clear();
            using SchoolDbContext db = new SchoolDbContext();

            Console.WriteLine("\nAlla elever sorterade på förnamn i stigande ordning: ");

            var firstNameAsc = db.Students.OrderBy(s => s.FirstName);
            foreach (var student in firstNameAsc)
            {
                Console.WriteLine($"\n{student.FirstName} {student.LastName} med student ID: {student.StudentId}");
            }

            Console.ReadLine();
        }

        public static void FirstNameDesc()
        {
            Console.Clear();
            using SchoolDbContext db = new SchoolDbContext();

            Console.WriteLine("\nAlla elever sorterade på förnamn i fallande ordning: ");

            var firstNameDesc = db.Students.OrderByDescending(s => s.FirstName);
            foreach (var student in firstNameDesc)
            {
                Console.WriteLine($"\n{student.FirstName} {student.LastName} med student ID: {student.StudentId}");
            }

            Console.ReadLine();
        }

        public static void LastNameAsc()
        {
            Console.Clear();
            using SchoolDbContext db = new SchoolDbContext();

            Console.WriteLine("\nAlla elever sorterade på efternamn i stigande ordning: ");

            var lastNameAsc = db.Students.OrderBy(s => s.LastName);
            foreach (var student in lastNameAsc)
            {
                Console.WriteLine($"\n{student.FirstName} {student.LastName} med student ID: {student.StudentId}");
            }

            Console.ReadLine();
        }

        public static void LastNameDesc()
        {
            Console.Clear();
            using SchoolDbContext db = new SchoolDbContext();

            Console.WriteLine("\nAlla elever sorterade på efternamn i fallande ordning: ");

            var lastNameDesc = db.Students.OrderByDescending(s => s.LastName);
            foreach (var student in lastNameDesc)
            {
                Console.WriteLine($"\n{student.FirstName} {student.LastName} med student ID: {student.StudentId}");
            }

            Console.ReadLine();
        }

        public static void GetStudentsFromClass()
        {
            Console.Clear();
            using SchoolDbContext db = new SchoolDbContext();

            Console.WriteLine("\nAlla klasser på skolan, välj en klass för att se alla elever i den\n");

            var classes = db.Students.GroupBy(s => s.Class).Select(group => group.First());
            int num = 1;
            foreach (var student in classes)
            {
                Console.WriteLine(student.Class);
                num++;
            }

            Console.Write("\nSkriv in ditt val: ");

            var className = Console.ReadLine().ToUpper();

            bool classExists = db.Students.Any(s => s.Class == className);

            if (!classExists)
            {
                Console.WriteLine($"\nKlassen {className} existerar inte");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"\nAlla elever i klassen {className}:");

                var studentInClass = db.Students.Where(s => s.Class == className);

                foreach (var student in studentInClass)
                {
                    Console.WriteLine($"\n{student.FirstName} {student.LastName} med student ID: {student.StudentId}");
                }
                Console.ReadLine();
            }
        }
    }
}
