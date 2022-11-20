using Folders;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = "";
        string folder_name = "";
        List<string> dirs = new();
        class_arrow my_arrow = new class_arrow();

        Console.SetCursorPosition(50, 0);
        Console.WriteLine("Этот компьютер");
        Console.WriteLine("------------------------------------------------------------------------" +
            "------------------------------------------------");
        Console.WriteLine("");

        DriveInfo[] allDrives = DriveInfo.GetDrives();
        foreach (DriveInfo d in allDrives)
        {
            if (d.IsReady == true)
            {
                Console.WriteLine($"  {d.Name} Свободно {Convert.ToDouble(d.TotalFreeSpace / 1024 / 1024 / 1024)} GB " +
                    $"из {Convert.ToDouble(d.TotalSize / 1024 / 1024 / 1024)} GB");
                dirs.Add(d.Name);
            }

        }

        Console.SetCursorPosition(0, my_arrow.y);
        Console.WriteLine(my_arrow.arrow);
        my_arrow.arrov_max = allDrives.Length + 2;
        while (true)
        {
            ConsoleKeyInfo PressedKey = Console.ReadKey();
            switch (PressedKey.Key)
            {
                case ConsoleKey.DownArrow:
                    if (my_arrow.y < my_arrow.arrov_max)
                    {
                        Console.SetCursorPosition(0, my_arrow.y);
                        Console.WriteLine(my_arrow.arrow.Replace("->", "  "));
                        Console.SetCursorPosition(0, ++my_arrow.y);
                        Console.WriteLine(my_arrow.arrow);
                    }
                    else if (dirs.Count == 1)
                    {
                        Console.SetCursorPosition(0, my_arrow.min);
                        Console.WriteLine(my_arrow.arrow.Replace("->", "  "));
                        Console.SetCursorPosition(0, my_arrow.min);
                        Console.WriteLine(my_arrow.arrow);
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (my_arrow.y > my_arrow.min)
                    {
                        Console.SetCursorPosition(0, my_arrow.y);
                        Console.WriteLine(my_arrow.arrow.Replace("->", "  "));
                        Console.SetCursorPosition(0, --my_arrow.y);
                        Console.WriteLine(my_arrow.arrow);
                    }
                    break;
                case ConsoleKey.Enter:
                    path = dirs[my_arrow.y - my_arrow.min];
                    Console.Clear();
                    HeaderUp();
                    Scan.ScanDirectory(path, dirs, my_arrow);
                    Draw();
                    my_arrow.arrov_max = dirs.Count + 2;
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine(path);
                    my_arrow.y = 3;
                    break;
                case ConsoleKey.Escape:
                    path = path.Replace(path.Split("\\").Last(), "");
                    if (path.Length > 3)
                    {
                        path = path.Remove(path.Length - 1);
                    }
                    else if (path.Length < 3)
                    {
                        Console.Clear();
                        Main(args);
                    }
                    Console.Clear();
                    HeaderUp();
                    Scan.ScanDirectory(path, dirs, my_arrow);
                    Draw();
                    my_arrow.arrov_max = dirs.Count + 2;
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine(path);
                    break;
                case ConsoleKey.F1:
                    Console.SetCursorPosition(91, 8);
                    Console.WriteLine("Введите название папки:");
                    Console.SetCursorPosition(91, 9);
                    folder_name = Console.ReadLine();
                    Directory.CreateDirectory(path+folder_name);
                    Console.Clear();
                    HeaderUp();
                    Scan.ScanDirectory(path, dirs, my_arrow);
                    Draw();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine(path);
                    break;
                case ConsoleKey.F2:
                    Console.SetCursorPosition(91, 8);
                    Console.WriteLine("Введите название файла:");
                    Console.SetCursorPosition(91, 9);
                    folder_name = Console.ReadLine();
                    File.WriteAllText(path+"\\"+folder_name, "");
                    Console.Clear();
                    HeaderUp();
                    Scan.ScanDirectory(path, dirs, my_arrow);
                    Draw();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine(path);
                    break;
                case ConsoleKey.F3:
                    if (dirs[my_arrow.y - my_arrow.min].Contains("."))
                    {
                        File.Delete(dirs[my_arrow.y - my_arrow.min]);
                    }
                    else
                    {
                        Directory.Delete(dirs[my_arrow.y - my_arrow.min]);
                    }
                    Console.Clear();
                    HeaderUp();
                    Scan.ScanDirectory(path, dirs, my_arrow);
                    Draw();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine(path);
                    break;
            }
        }

        static void HeaderUp()
        {
            Console.SetCursorPosition(50, 0);
            Console.WriteLine("Этот компьютер");
            Console.WriteLine("------------------------------------------------------------------------" +
                "------------------------------------------------");
            Console.WriteLine("\tНазвание\t\t\t\tДата создания\t\tТип");   
        }
        static void Draw()
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
    }
}