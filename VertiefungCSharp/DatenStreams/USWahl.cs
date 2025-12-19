using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
        public override string ToString()
        {
            return $"ID: {ID,5} {Vorname,20} {Nachname,20} {PLZ,6} {Alter,11} {Zugehörigkeit,20} {Schicht}";
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

    public static class Model
    {
        public static List<Person> Wähler = new List<Person>();
        public static void GenereteValues(int anzahl)
        {
            using StreamReader srVW = new StreamReader("vornamen_w.txt");
            string[] vW = srVW.ReadToEnd().Replace("\r", "").Split("\n");

            using StreamReader srVM = new StreamReader("vornamen_m.txt");
            string[] vM = srVM.ReadToEnd().Replace("\r", "").Split("\n");

            using StreamReader srN = new StreamReader("nachnamen.txt");
            string[] Nach = srN.ReadToEnd().Replace("\r", "").Split("\n");

            Random rnd = new Random();
            for (int i = 0; i < anzahl; i++)
            {
                int plz = rnd.Next(10_000, 100_000);// der unterstrich _ verändert den int wert nicht
                int einfluss = rnd.Next(Enum.GetNames(typeof(Beeinflussbarkeit)).Length);//Beispiel für dynamisch Länge wenn wir das enum verändern/ oder länge unbelkannt ist
                int alter = rnd.Next(6);
                int geschlecht = rnd.Next(2);
                int schicht = rnd.Next(4);
                int lager = rnd.Next(2);
                int nachname = rnd.Next(Nach.Count());
                int vorname;
                string name;

                if ((Geschlecht)geschlecht == Geschlecht.MAENNLICH)
                {
                    vorname = rnd.Next(vM.Count());
                    name = vM[vorname];
                }
                else
                {
                    vorname = rnd.Next(vW.Count());
                    name = vW[vorname];
                }
                Wähler.Add(
                    new Person(name, Nach[nachname],
                    plz.ToString(),
                    (Geschlecht)geschlecht,
                    (Schicht)schicht,
                    (Alter)alter,
                    (PolitischesLager)lager,
                    (Beeinflussbarkeit)einfluss)
                    );
            }

        }
        public static List<Person> GetVoters() { return Wähler; }
    }
    internal class USWahl
    {
        public static void TuWas()
        {
            Model.GenereteValues(10_000);
            List<Person> Wahlvolk = Model.GetVoters();
            //Weibliche Erstwähler im PLZ-Bereich 3xxxx aus der oberen Mittelschicht die vermutlich die Republikaner wählen werden.
            var WeiblErst = Wahlvolk.Where(x =>
            x.Geschlecht == Geschlecht.WEIBLICH &&
            x.Schicht == Schicht.OBEREMITTELSCHICHT &&
            x.Zugehörigkeit == PolitischesLager.REPUBLIKANER &&
            x.Alter == Alter.ERSTWAEHLER &&
            x.PLZ.First() == '3');

            foreach (var s in WeiblErst)
            {
                Console.WriteLine(s);
            }
            //Wähler über 50 die den Demokraten zugetan sind aber sehr leicht beeinflussbar sind.
            var groß50Demo = Model.GetVoters().Where(
                x => (x.Alter == Alter.BIS60 || x.Alter == Alter.SONSTIGE) &&
                x.Zugehörigkeit == PolitischesLager.DEMOKRATEN &&
                x.Einfluss == Beeinflussbarkeit.LEICHT
                );

            foreach (var s in groß50Demo)
            {
                Console.WriteLine(s);
            }

            //Wähler aus der Oberschicht, die sich nicht beeinflussen lassen und sich den Republikanern zurechnen.
            var RepOberschicht = Wahlvolk.Where(x =>
                x.Schicht == Schicht.OBERSCHICHT &&
                x.Einfluss == Beeinflussbarkeit.SCHWER &&
                x.Zugehörigkeit == PolitischesLager.REPUBLIKANER
                );
            foreach (var s in RepOberschicht)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine(RepOberschicht.Count() + groß50Demo.Count() + WeiblErst.Count());
        }
    }
}
