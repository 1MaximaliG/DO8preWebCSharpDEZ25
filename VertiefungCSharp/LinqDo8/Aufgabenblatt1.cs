using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Numerics;
using System.Text;

namespace LinqDo8
{
    internal class Aufgabenblatt1
    {
        public static void TuWas()
        {
            //Aufgabe 1
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0, 22, 12, 16, 18, 11, 19, 13 };
            var extseven = numbers.Where(n => n < 7);
            var QuerySeven =
                from n in numbers
                where n < 7
                select n;
            //a
            var resultinteger = new string[6, 2];
            resultinteger[0, 0] = "Extension Method";
            resultinteger[1, 0] = string.Join(", ", numbers.Where(n => n < 7));
            resultinteger[0, 1] = "Query Experssion";
            resultinteger[1, 1] = string.Join(", ", from n in numbers where n < 7 select n);
            //b
            var evennumbers = numbers.Where(number => number % 2 == 0);
            resultinteger[2, 0] = string.Join(", ", evennumbers);
            var evennumbers2 = from numb in numbers where numb % 2 == 0 select numb;
            resultinteger[2, 1] = string.Join(", ", evennumbers2);
            //c
            var oddunter10 = numbers.Where(n => n % 2 != 0 && n < 10);
            resultinteger[3, 0] = string.Join(", ", oddunter10);
            var oddunter10b = from n in numbers where n % 2 != 0 && n < 10 select n;
            resultinteger[3, 1] = string.Join(", ", oddunter10b);
            //d
            var gradeAbSechstes = from n in numbers.Skip(5) where n % 2 == 0 select n;
            resultinteger[4, 0] = string.Join(", ", gradeAbSechstes);
            var gradeAbSechstes2 = numbers.Skip(5).Where(n => n % 2 == 0);
            resultinteger[4, 1] = string.Join(", ", gradeAbSechstes2);
            //e
            var teilbar = numbers.Where(n => n % 2 == 0 || n % 3 == 0);
            resultinteger[5, 0] = string.Join(", ", teilbar);
            var teilbarB = from n in numbers where n % 2 == 0 || n % 3 == 0 select n;
            resultinteger[5, 1] = string.Join(", ", teilbarB);


            for (int i = 0; i < resultinteger.GetLength(0); i++)
            {
                Console.WriteLine($"{resultinteger[i, 0],-40} | {resultinteger[i, 1]}");
            }
            //Aufgabe 2

            string[] numbersS = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen" };
            var resultstring = new string[7, 2];
            resultstring[0, 0] = "Extension Method";
            resultstring[0, 1] = "Query Expression";
            //a
            resultstring[1, 0] = string.Join(", ", numbersS.Where(w => w.Length == 3));
            resultstring[1, 1] = string.Join(", ", from n in numbersS where n.Length == 3 select n);
            //b
            resultstring[2, 0] = string.Join(", ", numbersS.Where(str => str.Contains('o')));
            resultstring[2, 1] = string.Join(", ", from str in numbersS where str.Contains('o') select str);
            //c
            resultstring[3, 0] = string.Join(", ", numbersS.Where(m => m.EndsWith("teen")));
            resultstring[3, 1] = string.Join(", ", from n in numbersS where n.EndsWith("teen") select n);
            //d
            resultstring[4, 0] = string.Join(", ", numbersS.Where(m => m.EndsWith("teen")).Select(n => n.ToUpper()));
            resultstring[4, 1] = string.Join(", ", from n in numbersS where n.EndsWith("teen") select n.ToUpper());
            //e
            resultstring[5, 0] = string.Join(", ", numbersS.Where(nummer => nummer.Contains("four")).Select(n => n));
            resultstring[5, 1] = string.Join(", ", from n in numbersS where n.Contains("four") select n);
            //f
            resultstring[6, 0] = string.Join(", ", numbersS.Where(number => number.StartsWith("t") != true && number.StartsWith("f")!= true));
            resultstring[6, 1] = string.Join(", ", from n in numbersS where !(n.StartsWith("t") || n.StartsWith("f")) select n);

            for (int i = 0; i < resultstring.GetLength(0); i++)
            {
                Console.WriteLine($"{resultstring[i, 0],-40} | {resultstring[i, 1]}");
            }


        }
    }
}
