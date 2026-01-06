namespace Threads
{
    internal partial class Program
    {
        public class ParallelBeispiel1
        {
            public static void TuWas()
            {
                Parallel.Invoke(
                    () => Methode1("-"),
                    () => Methode1("+"),
                    () => Methode1("|"));
                Console.ReadLine();

            }
            static void Methode1(string s)
            {
                for(int i=0; i < 500; i++)
                {
                    Console.Write(s);
                    Thread.Sleep(1);
                }
            }
        }
    }
}
