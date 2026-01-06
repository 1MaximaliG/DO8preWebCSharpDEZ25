namespace Threads
{
    internal partial class Program
    {
        public class ParallelBeispiel2
        {
            public static void TuWas()
            {
                Data[] data = new Data[100];
                for(int i = 0; i< data.Length; i++)
                {
                    data[i] = new Data();
                }

                Parallel.ForEach(data, (d) => d.Prozess());
                Console.ReadLine();

                Parallel.For(0, data.Length, (i) => data[i].Prozess());
                Console.ReadLine();

            }
            class Data
            {
                public void Prozess()
                {
                    Thread.Sleep(500);
                    Console.WriteLine(Environment.CurrentManagedThreadId);
                }
            }
        }
    }
}
