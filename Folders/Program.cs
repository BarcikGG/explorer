using Folders;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = "";
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
                    dop_actions.Draw();
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
                    dop_actions.Draw();
                    my_arrow.arrov_max = dirs.Count + 2;
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine(path);
                    break;
                case ConsoleKey.F1:
                    dop_actions.F1(path);
                    Directory.CreateDirectory(path+dop_actions.folder_name);
                    Console.Clear();
                    HeaderUp();
                    Scan.ScanDirectory(path, dirs, my_arrow);
                    dop_actions.Draw();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine(path);
                    break;
                case ConsoleKey.F2:
                    dop_actions.F2(path);
                    Console.Clear();
                    HeaderUp();
                    Scan.ScanDirectory(path, dirs, my_arrow);
                    dop_actions.Draw();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine(path);
                    break;
                case ConsoleKey.F3:
                    dop_actions.F3(dirs, my_arrow);
                    Console.Clear();
                    HeaderUp();
                    Scan.ScanDirectory(path, dirs, my_arrow);
                    dop_actions.Draw();
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

    }
}