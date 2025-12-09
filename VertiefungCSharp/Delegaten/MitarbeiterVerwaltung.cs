using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Delegaten
{
    //Notwendige Klasse
    public class Mitarbeiter
    {
        private string _name;
        private int _alter;
        private decimal _gehalt;
        public string Name
        {
            get { return _name; }
             set { _name = value; }
        }
        public int Alter
        {
            get { return _alter; }
            set { _alter = value; }
        }
        public decimal Gehalt
        {
            get { return _gehalt; }
            set { _gehalt = value; }
        }
        public Mitarbeiter(string name, int alter, decimal gehalt)
        {
            _alter = alter;
            _name = name;
            _gehalt = gehalt;
        }
        public Mitarbeiter()
        {
            
        }
        public override string ToString()
        {
            return $"{Name,-25} : {Alter,5}   {Gehalt,9}";
        }
    }
    //Delegate
    public delegate bool MitarbeiterFilter(Mitarbeiter mitarbeiter);
    //Aufgabe
    public class MitarbeiterVerwaltung
    {
        public static List<Mitarbeiter> filternMitarbeiter(List<Mitarbeiter> liste, MitarbeiterFilter filter)
        {
            List<Mitarbeiter> ergebnis = new List<Mitarbeiter>();
            foreach (Mitarbeiter m in liste)
            {
                if (filter(m))
                {
                    ergebnis.Add(m);
                }
            }
            return ergebnis;
        }
        public static List<Mitarbeiter> SortierenMitarbeiter(List<Mitarbeiter> liste, Comparison<Mitarbeiter> filter)
        {
            liste.Sort(filter);
            return liste;
        }
        //Weiterleitung an die Main
        public static void TuWas()
        {
            Mitarbeiter neuer = new Mitarbeiter { Alter = 20, Gehalt = 25, Name = "Hoerst" };
            Comparison<Mitarbeiter> nachGehalt = (m1, m2) => m1.Gehalt.CompareTo(m2.Gehalt);
            List<Mitarbeiter> liste = new List<Mitarbeiter>
            {
                new Mitarbeiter("Donald Duck", 35, 3500.00m),
                new Mitarbeiter("Dagobert Duck", 75, 100000.00m),
                new Mitarbeiter("Daisy Duck", 32, 3200.00m),
                new Mitarbeiter("Darkwing Duck", 40, 6000.00m),
                new Mitarbeiter("Daniel Düsentrieb", 65, 7500.00m),
                new Mitarbeiter("Mac Moneysac", 70, 95000.00m),
                new Mitarbeiter("Gustav Gans", 38, 2000.00m),
                new Mitarbeiter("Bubba", 30, 1800.00m),
                new Mitarbeiter("Tick Duck", 10, 0.00m),
                new Mitarbeiter("Trick Duck", 10, 0.00m),
                new Mitarbeiter("Track Duck", 10, 0.00m)
            };
            List<Mitarbeiter> gefiltert = MitarbeiterVerwaltung.filternMitarbeiter(liste, ma => ma.Gehalt > 50000);

            //foreach (Mitarbeiter m in gefiltert)
            //{
            //    Console.WriteLine(m);
            //}

            List<Mitarbeiter> neu = MitarbeiterVerwaltung.SortierenMitarbeiter(liste, (m1,m2) => m1.Alter.CompareTo(m2.Alter));

            foreach (Mitarbeiter m in neu)
            {
                Console.WriteLine(m);
            }
        }
    }
}
