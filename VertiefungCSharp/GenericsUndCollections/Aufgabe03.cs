using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GenericsUndCollections
{
    public enum Kartenfarbe
    {
        Herz,
        Pik,
        Karo,
        Kreuz
    }
    public enum Kartenwert
    {
        Sieben = 7,
        Acht,
        Neun,
        Zehn,
        Bube,
        Dame,
        König,
        Ass
    }
    public class Karte(Kartenfarbe farbe, Kartenwert wert)
    {
        //vorsicht Primary Constructor
        //.Net 8 und älter braucht eigenen Contructor
        private Kartenfarbe _farbe = farbe;
        private Kartenwert _wert = wert;
        public Kartenfarbe Farbe { get { return _farbe; } }
        public Kartenwert Wert { get { return _wert; } }

        ////für .Net 8 und älter
        //public Karte(Kartenfarbe farbe, Kartenwert wert)
        //{
        //    _farbe = farbe;
        //    _wert = wert;
        //}
        public static Stack<Karte> FarbenStapel(Kartenfarbe farbe)
        {
            Stack<Karte> stapel = new();
            //var allewerte = Enum.GetValues<Kartenwert>;
            foreach (Kartenwert w in Enum.GetValues<Kartenwert>())
            {
                stapel.Push(new Karte(farbe, w));
            }
            return stapel;
        }
        //allgemeine methode zum aufteilen des Stapels in X kleinere
        public static List<Stack<Karte>> StapelAufteilen(int anzahl, Stack<Karte> stapel)
        {
            if(anzahl !> 0)
            {
                throw new InvalidDataException();//oder out of range
            }
            List<Stack<Karte>> ergebnis = new();
            //int karten = stapel.Count / anzahl;
            //for (int i = 0; i< anzahl; i++)
            //{
            //    Stack<Karte> speicher = new();
            //    for(int y =0; y < karten; y++)
            //    {
            //        speicher.Push(stapel.Pop());
            //    }
            //    ergebnis.Add(speicher);
            //}
            for (int i = 0; i < anzahl; i++)
            {
                ergebnis.Add(new Stack<Karte>());
            }
            while (stapel.Count > 0)
            {
                foreach(Stack<Karte> s in ergebnis)
                {
                    if (stapel.Count > 0)
                        s.Push(stapel.Pop());
                    else
                        break;
                }
            }
            return ergebnis;
        }

        public override string ToString()
        {
            return $"{_farbe} {_wert}";
        }
    }
    internal class Aufgabe03
    {
        public static void TuWas()
        {
            Stack<Karte> PStapel = Karte.FarbenStapel(Kartenfarbe.Pik);
            Stack<Karte> HStapel = Karte.FarbenStapel(Kartenfarbe.Herz);
            Stack<Karte> beide = new();
            int count = HStapel.Count();
            for (int i = 0; i < count; i++)
            {
                beide.Push(HStapel.Pop());
                beide.Push(PStapel.Pop());
            }
            foreach (Karte k in beide)
            {
                Console.WriteLine(k);
            }

            Stack<Karte> eins = new();
            eins.Push(4, beide);//ist hier möglich wegen der erweiterung StackExtension
            Stack<Karte> zwei = new();
            zwei.Push(4, beide);
            Stack<Karte> drei = new();
            drei.Push(4, beide);
            Stack<Karte> vier = new();
            vier.Push(4, beide);
            //Refactor zu allgemeiner Methode

            List<Stack<Karte>> vierStapel = Karte.StapelAufteilen(4, beide);//als alternative zu der vier einzelnen

            //eins auf drei und zwei auf vier
            drei.Push(eins);
            vier.Push(zwei);

            Stack<Karte> alle = new();
            alle.Push(vier);
            alle.Push(drei);
            Console.WriteLine("_________________________________");
            foreach (Karte k in alle)
            {
                Console.WriteLine(k);
            }
        }
    }
    public static class StackExtension
    {
        public static void Push<T>(this Stack<T> stack, int count, Stack<T> other)
        {
            for (int i = 0; i < count; i++)
            {
                stack.Push(other.Pop());
            }
        }
        public static void Push<T>(this Stack<T> stack, Stack<T> other)
        {
            int count = other.Count();
            stack.Push(count, other);//siehe obern ^^
        }
    }
}
