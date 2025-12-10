using System.Globalization;

namespace LinqDo8
{
    internal class Aufgabenblatt2
    {
        public static void TuWas()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0, 22, 12, 16, 18, 11, 19, 13 };
            //a
            var erste5 = numbers.Take(5);
            var erste5b = from number in numbers[0..5] select number;
            //b
            var letzte5 = numbers.Skip(numbers.Length - 5);
            var letzte5b = numbers.TakeLast(5);
            var letzte5c = from number in numbers[(numbers.Length - 5)..] select number;
            //c
            var mitte = numbers.Skip(3).SkipLast(3);
            //d
            var bis22 = numbers.Take(numbers.IndexOf(22));
            var bis22b = numbers.TakeWhile(n => n != 22);
            var bis22c = numbers.Take(Array.IndexOf(numbers, 22));//wenn die erste version nicht funktioniert
            //e
            var nach12 = numbers.Skip(numbers.IndexOf(12));
            var nach12b = numbers.Skip(Array.IndexOf(numbers, 12));
            var nach12c = numbers.SkipWhile(n => n != 12).Skip(1);
            //f
            var offset = 0;
            while (offset < numbers.Count())
            {
                var ausgabe = numbers.Skip(offset).Take(5);
                offset += 5;
                foreach (var s in ausgabe)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
            }

            for (int i = 0; i < numbers.Length; i += 5)
            {
                Console.WriteLine($"Seite {(i / 5) + 1}:");
                for (int j = i; j < i + 5 && j < numbers.Length; j++)
                {
                    Console.WriteLine(numbers[j] + " ");
                }
                Console.WriteLine();
            }


            //foreach (var s in bis22b)
            //{
            //    Console.WriteLine(s);
            //}

        }
    }
}
