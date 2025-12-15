using System;
using System.Collections.Generic;
using System.Text;

namespace DatenStreams
{
    internal class Pfade
    {
        public static void TuWas()
        {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine(path);
            string[] parts = path.Split(Path.DirectorySeparatorChar);//nimmt das vom System verwenndete Trennzeichen für Ordner
            foreach (string s in parts)
            {
                Console.WriteLine(s);
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(parts[0]);
            for (int i = 1; i < parts.Length; i++)
            {
                sb.Append(Path.DirectorySeparatorChar);
                sb.Append(parts[i]);
            }
            sb.Append(Path.DirectorySeparatorChar);
            //sb.Append(@"!:^^ -#<<<>>""~³|q@");

            string newPath = sb.ToString();
            Console.WriteLine(newPath);

            string newJoin = string.Join(Path.DirectorySeparatorChar, parts);
            Console.WriteLine(newJoin);

            bool error = newPath
                .Intersect(Path.GetInvalidPathChars())// | wird hier als invalid angegeben
                .Any();
            Console.WriteLine(error);

            using (FileSystemWatcher watcher = new FileSystemWatcher(path))
            {
                watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;

                watcher.Created += Watcher_Changed;
                watcher.Changed += Watcher_Changed;
                watcher.Deleted += Watcher_Changed;

                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Watcher ist an: ");
                Console.ReadKey();
            }

        }
        static void Watcher_Changed(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"Datei {e.Name} {e.ChangeType}");
        }
    }
}
