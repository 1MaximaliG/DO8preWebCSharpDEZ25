using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;
using StringExtensionAufgaben;//möglich nach hinzufügen des Projekt verweises

namespace ErweiterungsMethoden
{
    public interface IInterface
    {
        void MethodeA();
    }
    public static class InterfaceExtension
    {
        public static void MethodeB(this IInterface i)
        {
            Console.WriteLine("Interface Extension");
        }
    }
    public class KlasseA : IInterface
    {
        public void MethodeA() { Console.WriteLine("Methode für das Interface"); }
    }
    public class PKW
    {

    }
    public class Cabrio : PKW
    {
        public void MethodeB()
        {
            Console.WriteLine("Cabrio Methode");
        }
    }
    public static class PKWExtension
    {
        public static void MethodeB(this PKW p)
        {
            Console.WriteLine("PKW erweiterung");
        }

    }
    public static class StringExtensions
    {
        public static string SwitchCase(this string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                sb.Append(char.IsUpper(c)
                    ? char.ToLower(c)
                    : char.ToUpper(c));
            }
            return sb.ToString();
        }
        public static string Left(this string s, int n)
        {
            return s.Substring(0, n);
        }
        public static string Right(this string s, int n)
        {

            return s.Substring(s.Length - n, n);
        }
        public static bool IsPalindrom(this string s)
        {
            char[] ca = s.ToCharArray();
            ca.Reverse();
            string rs = new string(ca);
            return String.Equals(s, rs, StringComparison.OrdinalIgnoreCase);
        }
        public static string Reverse(this string s)
        {
            char[] ca = s.ToCharArray();
            Array.Reverse(ca);
            return new string(ca);
        }
    }
    public static class IntegerExtensions
    {
        public static bool IsEven(this int n)
        {
            return n % 2 == 0;
        }
        public static bool IsOdd(this int n)
        {
            return !IsEven(n);
        }
        public static string IntToBin(this int n)
        {
            return Convert.ToString(n, 2);
        }
        public static string IntToHex(this int n)
        {
            return $"{n:X}";
        }
        public static int Power(this int b, int n = 2)
        {
            int result = 1;
            if (n >= 0)
            {
                for (int i = 0; i < n; i++)
                {
                    result = result * b;
                }
            }
            result = (int)Math.Pow((double)b, (double)n);//alternative
            return result;
        }
        public static int Power(this int b)// alternative zur direktzuweiseung siehe oben
        {
            return b.Power(2);
        }
    }
    public static class DoubkeExtensions
    {
        public static double RoundDown(this double d)
        {
            return (int)d;
        }
        public static double RoundUp(this double d)
        {
            return Math.Ceiling(d);
        }
        public static double RoundAt(this double d,double RundenBy)
        {
            double ganzeZahl = Math.Floor(d);
            double nachkommaZahl = d - ganzeZahl;
            if(RundenBy <= nachkommaZahl)
            {
                return Math.Ceiling(d);
            }
            else
            {
                return Math.Floor(d);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //string s ="Hello, World!";
            //s = s.SwitchCase();
            //Console.WriteLine(s);

            //Console.WriteLine("AbCdEf".SwitchCase());
            //PKW p = new PKW();
            //p.MethodeB();
            //Cabrio c = new Cabrio();
            //c.MethodeB();
            //p = c;
            //p.MethodeB();
            //KlasseA a = new KlasseA();
            //a.MethodeA();
            //a.MethodeB();
            //char[] ca1 = new char[4];
            //char[] c1 = new char[4];
            //Array.Reverse(ca1);
            //StringBuilder sb = new StringBuilder();

            //TN.TNDoMain();//Lösung von Calvin
            Console.WriteLine("Hello World!".Left(5));
            Console.WriteLine("Hello World!".Right(6));
            Console.WriteLine(42.IsEven());
            Console.WriteLine("Otto".IsPalindrom());
            Console.WriteLine("Hallo".Reverse());
            Console.WriteLine(30.IntToHex());
            Console.WriteLine(30.IntToBin());
            Console.WriteLine(5.Power(5));
            Console.WriteLine(5.Power());
            Console.WriteLine(9.999999999.RoundDown());
            Console.WriteLine(9.000000001.RoundUp());
            Console.WriteLine(1.6.RoundAt(0.6));
            Console.WriteLine(1.6.RoundAt(0.7));
        }
    }
}

