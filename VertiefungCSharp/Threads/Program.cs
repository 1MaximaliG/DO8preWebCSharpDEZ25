using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.ConstrainedExecution;

namespace Threads
{
    internal partial class Program
    {
        public class Traumschiff
        {
            public class Position(double x, double y)
            {
                public double X { get; set; } = x;
                public double Y { get; set; } = y;

                public override bool Equals(object? obj)
                {
                    if (obj is Position p)
                        return p.X == X && p.Y == Y;
                    return false;
                }
                public static bool operator ==(Position a, Position b)
                {
                    if (a is null)
                        return b is null;
                    return a.Equals(b);
                }
                public static bool operator !=(Position a, Position b)
                {
                    return !(a == b);
                }
            }
            public class Schiff
            {
                public static Lock Sperrer = new Lock();
                string _name;
                Position _standort;
                ConsoleColor _farbe;
                public Schiff(string name)
                {
                    Random r = new Random();
                    _name = name;
                    int x = r.Next(Console.WindowWidth - 1);
                    int y = r.Next(Console.WindowHeight - 1);
                    _standort = new Position(x, y);

                    _farbe = (ConsoleColor)r.Next(1, 16);//farben haben werte von 0 bis 15, 0 ist schwarz
                    ZeigeSchiff();
                }
                public void ZeigeSchiff()
                {
                    lock (Sperrer)
                    {
                        Console.SetCursorPosition((int)_standort.X, (int)_standort.Y);
                        Console.ForegroundColor = _farbe;
                        Console.Write(_name[0]);
                    }
                }
                public void LöscheSchiff()
                {
                    lock (Sperrer)
                    {
                        Console.SetCursorPosition((int)_standort.X, (int)_standort.Y);
                        Console.Write('.');
                    }
                }
                public void FahreHerum(int Anzahl)
                {
                    Random r = new Random();
                    for (int i = 0; i < Anzahl; i++)
                    {
                        Position ziel = new Position(r.Next(0, Console.WindowWidth - 1), r.Next(0, Console.WindowHeight - 1));
                        while (ziel != _standort)
                        {
                            LöscheSchiff();
                            if (_standort.X != ziel.X)
                                _standort.X += _standort.X - ziel.X < 0 ? 1 : -1;
                            if (_standort.Y != ziel.Y)
                                if (_standort.Y < ziel.Y)
                                    _standort.Y++;
                                else
                                    _standort.Y--;
                            ZeigeSchiff();
                            Thread.Sleep(337);
                        }
                    }
                }
            }

            public static void TuWas()
            {
                Schiff[] schiffe = new Schiff[] { new("Germania"), new("Persia"), new("Helvetica"), new("Moppetosse"), new("Pearl"), new("Dutchman"), new("Queen Annes Revenge"), new("Xanadu"), new("Nepomuk"), new("Aurora") };
                Parallel.ForEach(schiffe, (s) => s.FahreHerum(10));
                Console.ReadLine();
                Parallel.For(0,schiffe.Length, (i) => schiffe[i].FahreHerum(10));
                Console.ReadLine();


            }
        }

        static void Main(string[] args)
        {
            //Beispiel1.TuWas();
            //Beispiel2.TuWas();
            //BeispielCancel.TuWas();
            //ThreadPoolBeispiel.TuWas();
            //TaskBeispiel.TuWas();
            //ParallelBeispiel1.TuWas();
            //ParallelBeispiel2.TuWas();
            //AsyncBeispiel.TuWas();
            //AsyncBeispiel2.TuWas();
            //ThreadGrundlagen.TuWas();
            //BeispielFrühstück.TuWas();
            Traumschiff.TuWas();
        }
    }
}
