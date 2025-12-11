using System;
using System.Collections.Generic;
using System.Text;

namespace LinqDo8
{
    internal class Aufgabenblatt4
    {
        public static void TuWas()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0, 22, 12, 16, 18, 11, 19, 13 };

            //a
            var summeAlle = numbers.Sum();
            summeAlle = numbers.Aggregate(0, (total, next) => total + next);
            Console.WriteLine(summeAlle);
            //b
            var kleinste = numbers.Min();
            Console.WriteLine(kleinste);
            //c
            var groeste = numbers.Max();
            Console.WriteLine(groeste);
            //d
            var durchschnitt = numbers.Average();
            Console.WriteLine(durchschnitt);
            //e
            var kleinsteGrade = numbers.Where(n => n % 2 == 0).Min();
            Console.WriteLine(kleinsteGrade);
            //f
            var kleinsteungrade = numbers.Where(n => n % 2 == 1).Max();
            Console.WriteLine(kleinsteungrade);
            //g
            var summeGrade = numbers.Where(n => n % 2 == 0).Sum();
            Console.WriteLine(summeGrade);
            //h
            var durchschnittUngrade = numbers.Where(n => n % 2 == 1).Average();
            Console.WriteLine(durchschnittUngrade);
            //i
            var AnzahlGrade = numbers.Where(n => n % 2 == 0).Count();
            AnzahlGrade = numbers.Count(n => n % 2 == 0);
            Console.WriteLine(AnzahlGrade);
        }
    }
}
