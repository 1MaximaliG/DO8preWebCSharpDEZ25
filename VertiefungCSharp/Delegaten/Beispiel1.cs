using System;
using System.Collections.Generic;
using System.Text;

namespace Delegaten
{
    //Delegate liegt  ausserhalb der Klasse
    delegate void MyDelegate(string s);
    internal class Beispiel1
    {
        //Methode mit gleicher Signatur wie der Delegate
        public static void Methode1(string text)
        {
            Console.WriteLine("Methode 1: " + text);
        }
        public static void Methode2(string text)
        {
            Console.WriteLine("Methode 2: " + text);
        }
        public static void Methode3(string text)
        {
            Console.WriteLine("Methode 3: " + text);
        }
        public static void TuWas()
        {
            MyDelegate dele1 = new MyDelegate(Methode1);
            MyDelegate dele2 = new MyDelegate(Methode2);


            dele1.Invoke("Ein Text");
            dele2.Invoke("Ein anderer Text");
            MyDelegate dele = new MyDelegate(Methode1) + new MyDelegate(Methode3);
            dele += new MyDelegate(Methode2);
            dele += new MyDelegate(Methode1);

            dele -= new MyDelegate(Methode1);
            //dele -= new MyDelegate(Methode1);
        }
    }
}
