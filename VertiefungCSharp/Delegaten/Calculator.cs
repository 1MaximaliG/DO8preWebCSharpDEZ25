using System;
using System.Collections.Generic;
using System.Text;

namespace Delegaten
{
    public delegate int Operation(int n, int x);// gleich wie Func<int,int,int>
    public delegate void Display(int x, int y, Operation o);// gleich wie Action<int,int>
    public class Calculator
    {
        public static int Addition(int eins, int zwei)
        {
            return eins + zwei;
        }
        public static int Subtraktion(int eins, int zwei)
        {
            return eins - zwei;
        }
        public static int Multiplikation(int eins, int zwei)
        {
            return eins * zwei;
        }
        public static int Division(int eins, int zwei)
        {
            if (zwei == 0) { zwei = 1; }
            return eins / zwei;
        }
    }
    public class Anzeigen
    {
        public static void CalculatorAnzeige(int eins, int zwei, Operation operation)
        {
            Console.WriteLine($"das ergebnis ist {operation(eins, zwei)}");
        }
    }

    public class Aufgabe1
    {
        //wird von der Main gestartet
        public static void TuWas()
        {
            Display displayResult = Anzeigen.CalculatorAnzeige;

            displayResult.Invoke(2, 5, Calculator.Division);

            //Addition in einer Zeile
            displayResult.Invoke(4, 2, (int value1, int value2) => value1 + value2);
            Anzeigen.CalculatorAnzeige(4, 2, (int value1, int value2) => value1 + value2);//Addition
            Anzeigen.CalculatorAnzeige(4, 2, (int x, int y) => x * y);//Multiplikation
            Anzeigen.CalculatorAnzeige(4, 2, (int x, int y) => (int)Math.Pow(x,y));//Potenz
        }
    }

}
