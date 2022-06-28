
namespace Homework_7
{
    abstract class NotebookCommand
    {
        public abstract string Key { get; }
        public abstract string Description { get; }
        public abstract void Execute(Notebook notebook);
    }

    class WriteAllCommand : NotebookCommand
    {
        public override string Key => "1";
        public override string Description => "Вывести данные на экран";

        public override void Execute(Notebook notebook)
        {
            Write(notebook);
        }

        void Write(Notebook notebook)
        {
            for (int i = 0; i < notebook.NoteCount; i++)
            {
                Employee employee = notebook.GetEmployee(i);
                NotebookConsoleIO.Write(employee);
            }
        }
    }

    class AddNoteCommand : NotebookCommand
    {
        public override string Key => "2";
        public override string Description => "Заполнить данные и добавить новую запись в конец файла";

        public override void Execute(Notebook notebook)
        {
            notebook.Add(NotebookConsoleIO.ReadEmployee());
        }
    }

    class WriteByIdCommand : NotebookCommand
    {
        public override string Key => "3";
        public override string Description => "Вывести на экран данные записи с указанным ID";

        public override void Execute(Notebook notebook)
        {
            int id = NotebookConsoleIO.RequestInt("Введите ID");
            Employee employee = notebook.GetEmployeeById(id);
            NotebookConsoleIO.Write(employee);
        }
    }

    class DeleteNoteCommand : NotebookCommand
    {
        public override string Key => "4";
        public override string Description => "Удалить запись с указанным ID";

        public override void Execute(Notebook notebook)
        {
            int id = NotebookConsoleIO.RequestInt("Введите ID");
            notebook.Remove(id);
        }
    }

    class EditNoteCommand : NotebookCommand
    {
        public override string Key => "5";
        public override string Description => "Редактировать запись с указанным ID";

        public override void Execute(Notebook notebook)
        {
            int id = NotebookConsoleIO.RequestInt("Введите ID");
            int fieldNumber = NotebookConsoleIO.RequestInt("Введите номер поля");
            string newContent = NotebookConsoleIO.RequestString("Введите новое значение");
            notebook.Edit(id, fieldNumber, newContent);
        }
    }

    class WriteBetweenCreationDatesCommand : NotebookCommand
    {
        public override string Key => "6";
        public override string Description => "Вывести записи с датой создания в указанном промежутке";

        public override void Execute(Notebook notebook)
        {
            DateTime date0 = NotebookConsoleIO.RequestDateTime("Введите первую дату");
            DateTime date1 = NotebookConsoleIO.RequestDateTime("Введите вторую дату");

            if (date0 > date1)
            {
                var temp = date0;
                date0 = date1;
                date1 = temp;
            }

            var filteredEmployees = notebook.Employees.Where(emp => date0 <= emp.CreationDate && emp.CreationDate <= date1);
            NotebookConsoleIO.Write(filteredEmployees);
        }
    }

    class WriteSortedByCreationDateCommand : NotebookCommand
    {
        public override string Key => "7";
        public override string Description => "Вывести записи, отсортированные по дате создания";

        public override void Execute(Notebook notebook)
        {
            var employees = notebook.Employees.OrderBy(e => e.CreationDate);
            NotebookConsoleIO.Write(employees);
        }
    }
}
