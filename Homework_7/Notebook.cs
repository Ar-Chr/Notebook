using System.Linq;

namespace Homework_7
{
    class Notebook
    {
        public event Action ContentsChanged;

        List<Employee> employees = new List<Employee>();
        public IReadOnlyList<Employee> Employees => employees;

        public int NoteCount => employees.Count;

        public void Add(int id, DateTime creationTime, string fullName, int age, int height, DateTime birthDate, string birthPlace)
        {
            Employee employee = new Employee(id, creationTime, fullName, age, height, birthDate, birthPlace);
            Add(employee);
        }

        public void Add(Employee employee)
        {
            employees.Add(employee);
            ContentsChanged?.Invoke();
        }

        public void Remove(int id)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == id)
                {
                    employees.RemoveAt(i);
                    ContentsChanged?.Invoke();
                    return;
                }
            }
        }

        internal void Edit(int id, int fieldNumber, string newContent)
        {
            int index = GetEmployeeIndexById(id);
            if (index == -1)
            {
                Console.WriteLine("Запись с указанным ID отсутствует");
                return;
            }

            Employee employee = employees[index];

            switch (fieldNumber)
            {
                case 2:
                    employee.CreationDate = DateTime.Parse(newContent);
                    break;

                case 3:
                    employee.FullName = newContent;
                    break;

                case 4:
                    employee.Age = int.Parse(newContent);
                    break;

                case 5:
                    employee.Height = int.Parse(newContent);
                    break;

                case 6:
                    employee.BirthDate = DateTime.Parse(newContent);
                    break;

                case 7:
                    employee.BirthPlace = newContent;
                    break;

                default:
                    Console.WriteLine("Поле не существует, или его нельзя менять");
                    break;
            }

            employees[index] = employee;
            ContentsChanged?.Invoke();
        }

        public Employee GetEmployee(int noteNumber) => employees[noteNumber];

        public int GetEmployeeIndexById(int id)
        {
            for (int i = 0; i < employees.Count; i++)
                if (employees[i].Id == id)
                    return i;

            return -1;
        }

        public Employee GetEmployeeById(int id)
        {
            int index = GetEmployeeIndexById(id);
            return employees[index];
        }
    }
}