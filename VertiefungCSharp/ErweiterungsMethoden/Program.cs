using System.Text;


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
        public  void MethodeB()
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
            foreach (char c in s){
                sb.Append(char.IsUpper(c) 
                    ? char.ToLower(c) 
                    : char.ToUpper(c));
            }
            return sb.ToString();
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
            KlasseA a = new KlasseA();
            a.MethodeA();
            a.MethodeB();
            
        }
    }
}

