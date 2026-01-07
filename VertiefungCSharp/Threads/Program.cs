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
                    string _name;
                    Position _standort;
                    public Schiff(string name)
                    {
                        Random r = new Random();
                        _name = name;
                        int x = r.Next(Console.WindowWidth-1);
                        int y = r.Next(Console.WindowHeight-1);
                        _standort = new Position(x, y);
                        ZeigeSchiff();
                    }
                    public void ZeigeSchiff()
                    {
                        Console.SetCursorPosition((int)_standort.X, (int)_standort.Y);
                        Console.Write(_name[0]);
                    }
                    public void LöscheSchiff()
                    {
                        Console.SetCursorPosition((int)_standort.X, (int)_standort.Y);
                        Console.Write(' ');
                    }
                    public void FahreHerum()
                    {
                        Random r = new Random();
                        Position ziel = new Position(r.Next(0,Console.WindowWidth-1), r.Next(0,Console.WindowHeight-1));
                      

                        while (ziel != _standort)
                        {
                            LöscheSchiff();
                            if (_standort.X != ziel.X)
                                _standort.X += _standort.X - ziel.X < 0 ? 1 : -1;
                            if(_standort.Y != ziel.Y)
                                if (_standort.Y < ziel.Y)
                                    _standort.Y++;
                                else
                                    _standort.Y--;
                            ZeigeSchiff();
                            Thread.Sleep(500);
                        }
                    }

                }
                public static void TuWas()
                {
                    Schiff schiff = new Schiff("Germania");
                    schiff.FahreHerum();
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
                Console.ReadLine();
            }
        }
    }
