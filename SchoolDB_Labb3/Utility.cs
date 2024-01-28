using SchoolDB_Labb3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SchoolDB_Labb3
{
    internal static class Utility
    {
        public static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("\nVälkommen till Skoldatabasen! Vad vill du göra?" +
                "\n\n[1] Hämta alla elever" +
                "\n[2] Hämta alla elever i en viss klass" +
                "\n[3] Lägga till ny personal" +
                "\n[4] Hämta personal" +
                "\n\nSkriv in ditt val: "
                );

                var menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        StudentMethods.GetStudents();
                        break;

                    case "2":
                        StudentMethods.GetStudentsFromClass();
                        break;

                    case "3":
                        EmployeeMethods.AddEmployee();
                        break;

                    case "4":
                        EmployeeMethods.GetEmployees();
                        break;

                    default:
                        Console.WriteLine("\nDu måste välja mellan 1-3");
                        Console.ReadLine();
                        continue;
                }
            }
        }
    }
}
