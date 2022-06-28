using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_7
{
    static class IdGenerator
    {
        static int id = 0;
        static string path = "ID.txt";

        static bool loaded = false;

        public static int GetId()
        {
            if (!loaded)
                LoadId();

            id++;
            SaveId();
            return id;
        }

        static void LoadId()
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                return;
            }

            using (StreamReader reader = new StreamReader(path))
                id = int.Parse(reader.ReadLine());

            loaded = true;
        }

        static void SaveId()
        {
            if (!File.Exists(path))
                File.Create(path).Close();

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(id);
            }
        }

        public static void SynchronizeId(int currentMaxId)
        {
            if (id < currentMaxId)
                id = currentMaxId;
            SaveId();
        }
    }
}
