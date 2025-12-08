using System;
using System.Collections.Generic;
using System.Text;

namespace Delegaten
{
    delegate bool FilterDelegate(int value);
    internal class Beispiel2
    {
        public static bool IsEven(int value) { return value % 2 == 0; }
        public static bool IsOdd(int value) { return value % 2 != 0; }

        public static void ShowFilteredValues(int[] values, FilterDelegate filter)
        {
            foreach (int zahl in values)
            {
                if (filter(zahl))
                {
                    Console.WriteLine(zahl + " ");
                }
            }
        }
        public static void TuWas()
        {
            //dele.Invoke("Ein schöner Text");
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            FilterDelegate filter = IsOdd;
            //filter += IsEven;//ist möglich aber nicht sinnvoll

            ShowFilteredValues(array, filter);
        }
    }
}
