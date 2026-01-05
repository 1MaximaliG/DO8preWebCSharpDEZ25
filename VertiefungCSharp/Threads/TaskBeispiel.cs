namespace Threads
{
    internal partial class Program
    {
        public class TaskBeispiel
        {
            static int Methode1(int a, int b)//rückgabetyp
            {
                for (int i = 0; i < 30; i++) {
                    Console.WriteLine(i + "in methode 1");
                    Thread.Sleep(2000);
                }
                return a + b;
            }
            static string Methode2(object obj)//rückgabetyp
            {
                Thread.Sleep(2000);
                return ((string)obj).ToUpper(); 
            }
            public static void TuWas()
            {
                int zahl = 100;
                int zahl2 = 50;
                Task<int> t1 = Task.Run(() => Methode1(zahl, zahl2));
                //Task t1 = new Task(Methode1);
                //t1.Start();

                string name = "TaskParallelLibary";
                Task<string> t2 = Task.Factory.StartNew(Methode2, name);
                //Task t3 = Task.Factory.StartNew(Methode2, "Task 3");


                Console.WriteLine(t1.Result);
                Console.WriteLine(t2.Result);
                //t1.Wait(); t2.Wait(); 
                //t3.Wait();

                Console.WriteLine("ENDE");
                Console.ReadLine();
            }
        }
    }
}
