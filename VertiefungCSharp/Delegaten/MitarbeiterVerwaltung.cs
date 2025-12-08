using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Delegaten
{
    public class Mitarbeiter
    {
        private string _name;
        private int _alter;
        private decimal _gehalt;
        public string Name
        {
            get { return _name; }
            //Namensänderung geht nur beim Amt!!!XD
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
        public Mitarbeiter(string name,int alter, decimal gehalt)
        {
            _alter = alter;
            _name = name;
            _gehalt = gehalt;
        }
    }
    public delegate bool MitarbeiterFilter(Mitarbeiter mitarbeiter);
    public class MitarbeiterVerwaltung
    {
        public static List<Mitarbeiter> filternMitarbeiter(List<Mitarbeiter> liste, MitarbeiterFilter filter)
        {
            List<Mitarbeiter> ergebnis = new List<Mitarbeiter>();
            foreach(Mitarbeiter m in liste)
            {
                if (filter(m))
                {
                    ergebnis.Add(m);
                }
            }
            return ergebnis;
         }
        public static void TuWas()
        {
            Comparison<Mitarbeiter> nachGehalt = (m1, m2) => m1.Gehalt.CompareTo(m2.Gehalt);

        }
    }
}
