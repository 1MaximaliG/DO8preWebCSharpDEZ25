using System;
using System.Collections.Generic;
using System.Text;

namespace DatenStreams
{
    internal class Laufwerke
    {
        public static void TuWas()
        {
            //Main
            DriveInfo[] DriveInfos = DriveInfo.GetDrives();
            //Drive Statische klasse
            foreach(DriveInfo di in DriveInfos)
            {
                Console.Write("Drive: ");
                Console.WriteLine(di.Name);
                Console.Write("  Type: ");
                Console.WriteLine(di.DriveType);
                if (di.IsReady)
                {
                    Console.Write("  Format: ");
                    Console.WriteLine(di.DriveFormat);
                    Console.Write("  Label: ");
                    Console.WriteLine(di.VolumeLabel);
                    Console.Write("  Drive size: ");
                    Console.WriteLine(di.TotalSize);
                    Console.Write("  Free total: ");
                    Console.WriteLine(di.TotalFreeSpace);
                    Console.Write("  Free for User: ");
                    Console.WriteLine(di.AvailableFreeSpace);
                }
            }

        }
    }
}
