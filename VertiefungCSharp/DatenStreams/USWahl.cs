using System;
using System.Collections.Generic;
using System.Text;

namespace DatenStreams
{
    public class Person
    {
        private static int _IDZähler = 0;
        public int ID { get; }
        public string Vorname { get; }
        public string Nachname { get; }
        public string PLZ { get; }
        public Geschlecht Geschlecht { get; }
        public Alter Alter { get; }
        public Schicht Schicht { get; }
        public PolitischesLager Zugehörigkeit { get; }
        public Beeinflussbarkeit Einfluss { get; }
        public Person(string vor, string nach, string plz, Geschlecht geschlecht, Schicht schicht, Alter alter, PolitischesLager politik, Beeinflussbarkeit einfluss)
        {
            ID = ++_IDZähler;
            Vorname = vor;
            Nachname = nach;
            PLZ = plz;
            this.Geschlecht = geschlecht;
            this.Schicht = schicht;
            this.Alter = alter;
            Zugehörigkeit = politik;
            Einfluss = einfluss;
        }
    }
    public enum Beeinflussbarkeit
    {
        LEICHT, MITTEL, SCHWER
    }
    public enum Alter
    {
        ERSTWAEHLER, BIS30, BIS40, BIS50, BIS60, SONSTIGE
    }
    public enum Geschlecht
    {
        MAENNLICH, WEIBLICH
    }
    public enum Schicht
    {
        UNTERSCHICHT, UNTEREMITTELSCHICHT, OBEREMITTELSCHICHT, OBERSCHICHT
    }
    public enum PolitischesLager
    {
        REPUBLIKANER, DEMOKRATEN
    }

    internal class USWahl
    {
        public static void TuWas()
        {

        }
    }
}
