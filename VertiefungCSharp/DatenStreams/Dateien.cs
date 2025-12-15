using System;
using System.Collections.Generic;
using System.Text;

namespace DatenStreams
{
    internal class Dateien
    {
        public static void TuWas()
        {
            //Main
            FileInfo fi = new FileInfo("Test.txt");
            if (!fi.Exists)
            {
                using (StreamWriter sw = fi.CreateText())
                {
                    sw.WriteLine("Ein wenig Inhalt 2");
                }
            }
            Console.WriteLine(fi.FullName);
            Console.ReadLine();

            fi.MoveTo(@"C:\Temp\____test.txt");
            Console.WriteLine(fi.FullName);
            Console.ReadLine();

            fi.CopyTo(@".\neuertest.txt");
            Console.WriteLine(fi.FullName);
            Console.ReadLine();

            fi.Delete();
        }
    }
}
