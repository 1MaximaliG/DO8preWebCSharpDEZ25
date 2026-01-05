namespace Threads
{
    internal partial class Program
    {
        static int threadCount = 100;
        static CountdownEvent cdown = new CountdownEvent(threadCount);//signal
        public class ThreadPoolBeispiel
        {
            public static void TuWas()//Main
            {
                for(int i = 0; i < threadCount; i++)
                {
                    ThreadPool.QueueUserWorkItem(Methode1, i);
                }
                cdown.Wait();// signal
                Console.WriteLine("Ende!!!");
            }
            static void Methode1(object obj)
            {
                Console.WriteLine($"Thread {(int) obj, 2} startet  {ThreadPool.ThreadCount}");

                Thread.Sleep(500);

                Console.WriteLine($"Thread {(int) obj, 2} endet  {ThreadPool.ThreadCount}");
                cdown.Signal();//signal
            }
        }
    }
}
