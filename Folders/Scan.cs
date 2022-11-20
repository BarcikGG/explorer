using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Folders
{
    internal class Scan
    {
        public static void ScanDirectory(string path, List<string> dirs, class_arrow my_arrow)
        {  
            if (path.Contains("."))
            {
                var proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = path;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
            }
            else
            {
                dirs.Clear();
                foreach (string dir in Directory.GetDirectories(path))
                {
                    Console.WriteLine($"  {Path.GetFileName(dir)}\t\t{File.GetCreationTime(dir)}\t{Path.GetExtension(dir)}");
                    dirs.Add(dir);
                }
                foreach (string dir in Directory.GetFiles(path))
                {
                    Console.WriteLine($"  {Path.GetFileName(dir)}\t\t{File.GetCreationTime(dir)}\t{Path.GetExtension(dir)}");
                    dirs.Add(dir);
                }
                if (dirs.Count == 0)
                {
                    Console.WriteLine("Тут пусто :(");
                }
            }
        }
    }
}
