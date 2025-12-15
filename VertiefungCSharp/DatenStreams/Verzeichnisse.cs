using System;
using System.Collections.Generic;
using System.Text;

namespace DatenStreams
{
    internal class Verzeichnisse
    {
        public static void TuWas()
        {
            string path = "C:\\Users\\Max.Gronemann\\source\\neu";
            //Main
            DirectoryInfo di = new DirectoryInfo(path);
            //Directory statische alternative

            if (!di.Exists)
            {
                di.Create();
                di.CreateSubdirectory("test");
                di.CreateSubdirectory("test2");
                di.CreateSubdirectory("test3");

                FileSystemInfo[] infos = di.GetFileSystemInfos("*");

                foreach(var fsi in infos)
                {
                    Console.WriteLine(fsi.Name);
                }
                Console.ReadLine();
                di.Delete(true);
            }
            else
            {
                Console.WriteLine("Verzeichnis existiert schon");
            }
        }
    }
}
