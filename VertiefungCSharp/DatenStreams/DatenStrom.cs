using System;
using System.Collections.Generic;
using System.Text;

namespace DatenStreams
{
    internal class DatenStrom
    {
        public static void TuWas()
        {
            //Datei erstellen
            string fileName = "StreimWriter.txt";
            FileStream fs = File.Create(fileName);

            //Text in die Datei schreiben
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Ein wenig Text blabla");
            sw.WriteLine("Ein wenig mehr Text blabla");
            sw.Close();
            Console.ReadLine();
            // Text aus Datei lesen
            using(StreamReader sr = File.OpenText(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            //Datei Löschen
            File.Delete(fileName);

            //STREAMS BEENDEN!!!
            fs.Close();
        }
    }
}
