using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Homework_7
{
    internal class NotebookConsoleIO
    {
        static int[] padding = new int[] { 3, 16, 30, 3, 3, 10, 16 };

        public static void Write(Employee employee)
        {
            string[] data = employee
                .ToObjectArray()
                .Select((obj, i) => obj.ToString().PadRight(padding[i]))
                .ToArray();

            Console.WriteLine(string.Join(" | ", data));
        }

        public static void Write(IEnumerable<Employee> employees)
        {
            foreach (Employee employee in employees)
                Write(employee);
        }

        public static Employee ReadEmployee()
        {
            int id = IdGenerator.GetId();
            string fullName = RequestString("Введите Ф.И.О.");
            int age = RequestInt("Введите возраст");
            int height = RequestInt("Введите рост");
            DateTime birthDate = RequestDateTime("Введите дату рождения");
            string birthPlace = RequestString("Введите место рождения");

            return new Employee(id, DateTime.Now, fullName, age, height, birthDate, birthPlace);
        }

        public static int RequestInt(string message)
        {
            Console.WriteLine(message);
            return int.Parse(Console.ReadLine());
        }

        public static DateTime RequestDateTime(string message)
        {
            Console.WriteLine(message);
            return DateTime.Parse(Console.ReadLine());
        }

        public static string RequestString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
