using System.Diagnostics;

namespace Threads
{
    internal partial class Program
    {
        public class AsyncBeispiel
        {
            public  static void TuWas()
            {
                Console.WriteLine("Main start");
                DoCalc();
                Console.WriteLine("Main Ende!");
                Console.ReadLine();
            }
            static void DoCalc()
            {
                Task<int> t1 = Task.Run(() => Methode1(1));
                Task<int> t2 = Task.Run(() => Methode1(2));
                //Thread.Sleep(1500);
                int result1 = t1.Result;
                Console.WriteLine("zwischen den ergebnissen");
                int result2 = t2.Result;

                Console.WriteLine($"{result1 + result2} Ende Calc");
            }
            static int Methode1(int seed)
            {
                Console.WriteLine("     Methode1 Start");
                Thread.Sleep(5000);
                Console.WriteLine("     Methode1 Ende");
                return new Random(seed).Next(1000);
            }
        }
        public class AsyncBeispiel2
        {
            public static void TuWas()
            {
                Console.WriteLine("Main start");
                DoCalc();
                Console.WriteLine("Main Ende!");
                Console.ReadLine();
            }
            static async void DoCalc()
            {
                Task<int> t1 = Task.Run(() => Methode1(1));
                Task<int> t2 = Task.Run(() => Methode1(2));
                Thread.Sleep(1500);
                int result1 = await t1;
                Console.WriteLine("Zwischen den ergebnissen");
                int result2 = await t2;

                Console.WriteLine($"{result1 + result2} Ende Calc");
            }
            static int Methode1(int seed)
            {
                Console.WriteLine("     Methode1 Start");
                Thread.Sleep(5000);
                Console.WriteLine("     Methode1 Ende");
                return new Random(seed).Next(1000);
            }
        }
        static void Main(string[] args)
        {
            //Beispiel1.TuWas();
            //Beispiel2.TuWas();
            //BeispielCancel.TuWas();
            //BeispielFrühstück.TuWas();
            //ThreadPoolBeispiel.TuWas();
            //TaskBeispiel.TuWas();
            //ParallelBeispiel1.TuWas();
            //ParallelBeispiel2.TuWas();
            //AsyncBeispiel.TuWas();
            AsyncBeispiel2.TuWas();

        }
    }
}
