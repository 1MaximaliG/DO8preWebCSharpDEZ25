using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsUndCollections
{
    // Baumarkt
    public static class Baumarkt
    {
        public static Dictionary<string, List<string>> TextToKundeKey(string s)
        {
            //s = s.Replace(" ", "");//alternative zu StringSplitOptions
            Dictionary<string, List<string>> ergebniss = new Dictionary<string, List<string>>();
            string[] listenEintrag = s.Split("\n");
            //foreach (string zeile in listenEintrag)
            //{
            //    ergebniss.Add(zeile.Split(';')[0], zeile.Split(';')[1].Split(',').ToList());
            //}
            for (int i = 0; i < listenEintrag.Length; i++)
            {
                string key = listenEintrag[i].Split(';')[0];
                List<string> value = listenEintrag[i].Split(';')[1].Split(',',StringSplitOptions.TrimEntries).ToList();

                ergebniss.Add(key, value);
            }
            return ergebniss;
        }
        public static Dictionary<string,List<string>> KundenZuArtikelDictionary(Dictionary<string, List<string>> KundenBestellung)
        {
            Dictionary<string, List<string>> ergebniss = new();
            foreach (string kunde in KundenBestellung.Keys)
            {
                foreach(string artikel in KundenBestellung[kunde])
                {
                    if (ergebniss.ContainsKey(artikel))
                    {
                        if (!ergebniss[artikel].Contains(kunde))
                            ergebniss[artikel].Add(kunde);
                    }
                    else
                    {
                        ergebniss.Add(artikel, new List<string>{kunde});
                    }
                }
            }
            return ergebniss;
        }
    }
    public static class Aufgabe02
    {
        public static void Tuwas()
        {
            string liste = "0123; Hammer, Dübel, Nägel\n"
            + "4711; Kantholz, Säge, Nägel, Leim\n"
            + "8698; Schrauben, Dübel, Hänge-WC\n"
            + "9876; Fischfutter, Hammer, Säge\n"
            + "4862; Kantholz, Säge\n"
            + "3179; Schrauben, Schraubenzieher, Dübel\n"
            + "7410; Leim, Fischfutter\n"
            + "8520; Hänge-WC, Nägel, Säge";
            Dictionary<string, List<string>> Kunden = Baumarkt.TextToKundeKey(liste);


            foreach(var kunde in Kunden)
            {
                Console.WriteLine("Kundennummer: "+kunde.Key);
                foreach(string artikel in kunde.Value)
                {
                    Console.WriteLine("-"+artikel);
                }
                Console.WriteLine();
            }
            Dictionary<string, List<string>> Artikel = Baumarkt.KundenZuArtikelDictionary(Kunden);

            foreach (var artikel in Artikel)
            {
                Console.WriteLine("Artikel: " + artikel.Key);
                foreach (string kunde in artikel.Value)
                {
                    Console.WriteLine("-" + kunde);
                }
                Console.WriteLine();
            }

        }
    }
}
