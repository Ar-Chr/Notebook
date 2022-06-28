using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_7
{
    struct Employee
    {
        public int Id;
        public DateTime CreationDate;
        public string FullName;
        public int Age;
        public int Height;
        public DateTime BirthDate;
        public string BirthPlace;

        public Employee(int id, DateTime creationTime, string fullName, int age, int height, DateTime birthDate, string birthPlace)
        {
            Id = id;
            CreationDate = creationTime;
            FullName = fullName;
            Age = age;
            Height = height;
            BirthDate = birthDate;
            BirthPlace = birthPlace;
        }

        int GetAge()
        {
            int age = DateTime.Now.Year - BirthDate.Year;
            if (BirthDate.DayOfYear > DateTime.Now.DayOfYear)
                age--;
            return age;
        }

        public object[] ToObjectArray()
        {
            return new object[] { Id, CreationDate, FullName, Age, Height, BirthDate.ToShortDateString(), BirthPlace };
        }
    }  
}
