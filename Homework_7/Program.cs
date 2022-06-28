using System.Globalization;

namespace Homework_7
{
    class Program
    {
        static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("ru-RU");

            void RegisterCommand(Dictionary<string, NotebookCommand> commands, NotebookCommand command) =>
                commands.Add(command.Key, command);

            var writeCommand = new WriteAllCommand();
            var addNoteCommand = new AddNoteCommand();
            var writeByIdCommand = new WriteByIdCommand();
            var deleteNoteCommand = new DeleteNoteCommand();
            var editNoteCommand = new EditNoteCommand();
            var writeBetweenCreationDatesCommand = new WriteBetweenCreationDatesCommand();
            var writeSortedByCreationDateCommand = new WriteSortedByCreationDateCommand();

            Dictionary<string, NotebookCommand> commands = new Dictionary<string, NotebookCommand>();

            RegisterCommand(commands, writeCommand);
            RegisterCommand(commands, addNoteCommand);
            RegisterCommand(commands, writeByIdCommand);
            RegisterCommand(commands, deleteNoteCommand);
            RegisterCommand(commands, editNoteCommand);
            RegisterCommand(commands, writeBetweenCreationDatesCommand);
            RegisterCommand(commands, writeSortedByCreationDateCommand);

            string path = "Notebook.txt";

            Console.WriteLine("Команды:");
            foreach (var pair in commands)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value.Description}");
            }
                        
            Notebook notebook = new Notebook();
            foreach (Employee employee in NotebookFileIO.Read(path))
                notebook.Add(employee);

            notebook.ContentsChanged += () => NotebookFileIO.Write(notebook, path);

            while (true)
            {
                string commandKey = Console.ReadLine();
                if (!string.IsNullOrEmpty(commandKey))
                    commands[commandKey].Execute(notebook);
            }
        }
    }
}