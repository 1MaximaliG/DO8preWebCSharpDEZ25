using System;
using System.Collections.Generic;
using System.Text;

namespace Delegaten
{
    public delegate bool FilterDele(string s);
    public class ArrayFilterAufgabe
    {
        public static void ShowFilteredValues(string[] array, FilterDele filter)
        {
            foreach (string str in array)
            {
                if (filter(str))
                {
                    Console.WriteLine(str);
                }
            }
        }
        public static bool IsUpperCase(string text)
        {
            return text == text.ToUpper();
        }
        public static bool IsTimCase(string text)
        {
            return text.All(char.IsUpper);
        }


        public static void TuWas()
        {
            string[] array = new string[] { "Grüße!", "Muri Turi te Saluntant", "Romani ite Domum", "HALLO", "123456", "12ab34cd", "Omicron Perei 8" };
            ShowFilteredValues(array, IsTimCase);
            ShowFilteredValues(array, delegate (string s) { return s.All(char.IsUpper); });
            ShowFilteredValues(array, (string s) => { return s.All(char.IsUpper); });
            ShowFilteredValues(array, (string s) => s.All(char.IsUpper));
            ShowFilteredValues(array, (s) => s.All(char.IsUpper));
            ShowFilteredValues(array, s => s.All(char.IsUpper));
            ShowFilteredValues(array, s => s.All(char.IsLower));
            ShowFilteredValues(array, s => s.All(char.IsDigit));
            ShowFilteredValues(array, s => s.Contains("a"));
            ShowFilteredValues(array, s => s.Any(char.IsDigit));
            ShowFilteredValues(array, s =>
            {
                foreach (char c in s)
                {
                    if (char.IsDigit(c))
                        return true;
                }
                return false;
            });
            



        }
    }
}
