using System;
using System.Collections.Generic;
using System.Text;

namespace LinqDo8
{
    internal class Aufgabenblatt3
    {
        public static void TuWas()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0, 22, 12, 16, 18, 11, 19, 13 };
            //a
            var sortetdNumbersInt = numbers.OrderBy(n => n);
            var sortetdNumbersInt2 = from n in numbers orderby n select n;
            foreach (var n in sortetdNumbersInt)
                Console.Write(n + " ");
            Console.WriteLine();
            foreach (var n in sortetdNumbersInt2)
                Console.Write(n + " ");
            Console.WriteLine();
            //b
            var sortetdNumbersIntD = numbers.OrderByDescending(n => n);
            var sortetdNumbersIntD2 = from n in numbers orderby n descending select n;
            foreach (var n in sortetdNumbersIntD)
                Console.Write(n + " ");
            Console.WriteLine();
            foreach (var n in sortetdNumbersIntD2)
                Console.Write(n + " ");
            Console.WriteLine();
            //c
            var evenAssending = from n in numbers where n % 2 == 0 orderby n ascending select n;
            var evenAssending2 = numbers.Where(n => n % 2 == 0).OrderBy(n => n);
            foreach (var n in evenAssending)
                Console.Write(n + " ");
            Console.WriteLine();
            foreach (var n in evenAssending2)
                Console.Write(n + " ");
            Console.WriteLine();
            //d
            var result = numbers.Where(n => n >= 5 && n <= 11).OrderByDescending(n => n);
            var result2 = from n in numbers where n >=5 && n <= 11 orderby n descending select n;
            foreach (var n in result)
                Console.Write(n + " ");
            Console.WriteLine();
            foreach (var n in result2)
                Console.Write(n + " ");
            Console.WriteLine();

            string[] stringNumbers = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen" };
            //a
            var lengsort = stringNumbers.OrderBy(str => str.Length);
            var lengsort2 = from str in stringNumbers orderby str.Length select str;
            foreach (var n in lengsort)
                Console.Write(n + " ");
            Console.WriteLine();
            foreach (var n in lengsort2)
                Console.Write(n + " ");
            Console.WriteLine();
            //b
            var lengsortAD = stringNumbers.OrderBy(n => n.Length).ThenByDescending(n => n);
            var lengsortAD2 = from n in stringNumbers orderby n.Length, n descending select n;
            foreach (var n in lengsortAD)
                Console.Write(n + " ");
            Console.WriteLine();
            foreach (var n in lengsortAD2)
                Console.Write(n + " ");
            Console.WriteLine();
            //c
            var revers = stringNumbers.Reverse().ToArray();
            var revers2 = (from sn in stringNumbers select sn).Reverse();//keine richtige lösung möglich
            foreach (var n in revers)
                Console.Write(n + " ");
            Console.WriteLine();
            foreach (var n in revers2)
                Console.Write(n + " ");
            Console.WriteLine();
            //d
            var AscFirstDescLast = stringNumbers.OrderBy(n => n.First()).ThenByDescending(n => n.Last());
            var AscFirstDescLast2 = from str in stringNumbers orderby str[0], str[^1] descending select str;
            foreach (var n in AscFirstDescLast)
                Console.Write(n + " ");
            Console.WriteLine();
            foreach (var n in AscFirstDescLast2)
                Console.Write(n + " ");
            Console.WriteLine();
        }
    }
}
