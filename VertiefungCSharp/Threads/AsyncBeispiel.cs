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
    }
}
