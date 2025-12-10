using System;
using System.Collections.Generic;
using System.Text;

namespace LinqDo8
{
    public enum Länder { USA, GB, Germany }

    class Kunde
    {
        public string Name { get; private set; }
        public string Ort { get; private set; }
        public Länder Land { get; private set; }
        public Bestellung[] Bestellungen { get; private set; }

        public Kunde(string name, string ort, Länder land, Bestellung[] bestellungen)
        {
            Name = name;
            Ort = ort;
            Land = land;
            Bestellungen = bestellungen;
        }

        public override string ToString()
        {
            string result = $"{Name} - {Ort} - {Land}";
            foreach (Bestellung best in Bestellungen)
            {
                result += $"\n  {best}";
            }
            return result;
        }

        public static Kunde[] GetKundenListe()
        {
            return new Kunde[] {
                new Kunde("Walter", "Altenburg", Länder.Germany, new Bestellung[] {
                    new Bestellung(2, 4, "März", false)
                }),
                new Kunde("Thomas", "Berlin", Länder.Germany, new Bestellung[] {
                    new Bestellung(1, 11, "Juni", false),
                    new Bestellung(3, 19, "November", true)
                }),
                new Kunde("Holger", "Washington", Länder.USA, new Bestellung[] {
                    new Bestellung(5, 17, "November", true)
                }),
                new Kunde("Fernando", "New York", Länder.USA, new Bestellung[] {
                    new Bestellung(6, 12, "Juni", false)
                }),
                new Kunde("Alice", "London", Länder.GB, new Bestellung[] {
                    new Bestellung(4, 3, "Februar", true),
                    new Bestellung(2, 1, "Februar", false),
                    new Bestellung(3, 19, "Juni", true)
                })
            };
        }
    }

    class Bestellung
    {
        public int ProduktNr { get; private set; }
        public int Anzahl { get; private set; }
        public string Monat { get; private set; }
        public bool Versendet { get; private set; }

        public Bestellung(int produktNr, int anzahl, string monat, bool versendet)
        {
            ProduktNr = produktNr;
            Anzahl = anzahl;
            Monat = monat;
            Versendet = versendet;
        }

        public override string ToString()
        {
            return $"ProdNr: {ProduktNr}, Anzahl: {Anzahl}, Monat: {Monat}, Versand: {Versendet}";
        }
    }

    class Produkt
    {
        public int ProduktNr { get; private set; }
        public string Name { get; private set; }
        public decimal Preis { get; private set; }

        public Produkt(int produktNr, string name, decimal preis)
        {
            ProduktNr = produktNr;
            Name = name;
            Preis = preis;
        }

        public override string ToString()
        {
            return $"{ProduktNr} - {Name} - {Preis}";
        }

        public static Produkt[] GetProduktListe()
        {
            return new Produkt[] {
                new Produkt(1, "Marmelade", 5),
                new Produkt(2, "Quark", 10),
                new Produkt(3, "Mohrrüben", 15),
                new Produkt(4, "Käse", 20),
                new Produkt(5, "Honig", 25),
                new Produkt(6, "Mehl", 30)
            };
        }
    }

    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Kunde[] kunden = Kunde.GetKundenListe();
    //        Produkt[] produkte = Produkt.GetProduktListe();

    //        var kundennamen =
    //            from k in kunden
    //            select k.Name;

    //        foreach (var name in kundennamen)
    //        {
    //            Console.WriteLine(name);
    //        }

    //        Console.WriteLine("Fertig!");
            

    //    }
    //}
}
