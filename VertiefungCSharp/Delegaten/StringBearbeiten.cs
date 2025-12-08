using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Delegaten
{
    public delegate string ÄnderungsDelegate(string a);
    internal class StringBearbeiten
    {
        public static void StringÄndern(string[] array, ÄnderungsDelegate filter)
        {
            foreach (string s in array)
                Console.WriteLine(filter(s));
        }
        public static void TuWas()
        {
            string[] array = new string[] { "Grüße!", "Muri Turi te Saluntant", "Romani ite Domum", "HALLO", "123456", "12ab34cd", "Omicron Perei 8" };
            StringÄndern(array, s => new string('*', s.Length));
        
        }
    }

}
