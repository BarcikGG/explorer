using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folders
{
    internal class dop_actions
    {
        static public string folder_name = "";
        static public void Draw()
        {
            Console.SetCursorPosition(95, 4);
            Console.WriteLine("F1 - создать папку");
            Console.SetCursorPosition(95, 5);
            Console.WriteLine("F2 - создать файл");
            Console.SetCursorPosition(95, 6);
            Console.WriteLine("F3 - удалить");
            for (int i = 2; i < 8; i++)
            {
                Console.SetCursorPosition(90, i);
                Console.WriteLine("|");
            }
            for (int i = 91; i < 120; i++)
            {
                Console.SetCursorPosition(i, 7);
                Console.WriteLine("_");
            }
        }

        static public void F3(List<string> dirs, class_arrow my_arrow)
        {
            if (dirs[my_arrow.y - my_arrow.min].Contains("."))
            {
                File.Delete(dirs[my_arrow.y - my_arrow.min]);
            }
            else
            {
                Directory.Delete(dirs[my_arrow.y - my_arrow.min]);
            }
        }
        static public void F2(string path)
        {
            Console.SetCursorPosition(91, 8);
            Console.WriteLine("Введите название файла:");
            Console.SetCursorPosition(91, 9);
            folder_name = Console.ReadLine();
            File.WriteAllText(path + "\\" + folder_name, "");
        }
        static public void F1(string path)
        {
            Console.SetCursorPosition(91, 8);
            Console.WriteLine("Введите название папки:");
            Console.SetCursorPosition(91, 9);
            folder_name = Console.ReadLine();
        }
    }
}
