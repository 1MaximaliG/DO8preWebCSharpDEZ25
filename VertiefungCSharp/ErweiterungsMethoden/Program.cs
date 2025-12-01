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
            
            return s.Substring(s.Length - n,n);
        }
        public static bool IsPalindrom(this string s)
        {
            char[] ca = s.ToCharArray();
            ca.Reverse();
            string rs = new string(ca);
            return String.Equals(s,rs,StringComparison.OrdinalIgnoreCase);
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
        }
    }
}

