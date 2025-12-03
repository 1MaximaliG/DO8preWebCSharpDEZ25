using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsUndCollections
{
    internal class Aufgabe01
    {
        public static void TuWas()
        {
            string text = "15;D;Peter Schmidt;Wuppertal\n"
            + "17;D;Hans Meier;Düsseldorf\n"
            + "23;E;Regina Schulz;Mettmann\n"
            + "31;D;Kathrin Müller;Erkrath\n"
            + "32;E;Rudolf Kramer;Witten\n"
            + "35;E;Anne Kunze;Bremen";

            string[] zeile = text.Split("\n");
            foreach (string wort in zeile)
            {
                string[] parts = wort.Split(";");
                Console.WriteLine($"Zimmer {parts[0]}:");
                //umwandlung von Buchstabe in Wort
                if (parts[1] == "D")
                    Console.WriteLine($"Doppelzimmer");
                else
                    Console.WriteLine($"Einzelzimmer");

                //Aufteilen in Vor- und Nachname
                string[] name = parts[2].Split(' ');
                Console.WriteLine($"Vorname: {name[0]}");
                Console.WriteLine($"Nachname: {name[1]}");

                Console.WriteLine($"Wohnort: {parts[3]}");
            }
            //
        }
    }
}
