
using System.IO;

namespace Homework_7
{
    internal static class NotebookFileIO
    {
        public static void Write(Notebook notebook, string path)
        {
            if (!File.Exists(path))
                File.Create(path).Close();            
            
            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < notebook.NoteCount; i++)
                {
                    writer.WriteLine(string.Join('#', notebook.GetEmployee(i).ToObjectArray()));
                }
            };
        }

        public static IEnumerable<Employee> Read(string path)
        {
            if (!File.Exists(path))
                yield break;

            using (StreamReader reader = new StreamReader(path))
            {
                int maxId = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        break;

                    string[] splitLine = line.Split('#');

                    int id = int.Parse(splitLine[0]);
                    DateTime creationTime = DateTime.Parse(splitLine[1]);
                    string fullName = splitLine[2];
                    int age = int.Parse(splitLine[3]);
                    int height = int.Parse(splitLine[4]);
                    DateTime birthDate = DateTime.Parse(splitLine[5]);
                    string birthPlace = splitLine[6];

                    maxId = Math.Max(maxId, id);

                    yield return new Employee(id, creationTime, fullName, age, height, birthDate, birthPlace);
                }
                IdGenerator.SynchronizeId(maxId);
            };
        }
    }
}
