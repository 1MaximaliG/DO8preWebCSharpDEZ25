using System.Diagnostics;

namespace Threads
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            //Beispiel1.TuWas();
            //Beispiel2.TuWas();
            Thread t = new Thread(Method1);
            t.Start();
            Console.WriteLine("M: hinter Thread Start");
            Thread.Sleep(200);
            Console.WriteLine("M: vor Abort");
            //Abort worft nach dem catch automatisch wieder einer ThreadAbortException geworfen, was es fast unmöglich macht hier wieder elegant raus zu kommen
            //t.Abort();
            Console.WriteLine("M: nach Abort");
            Console.WriteLine("M: T ist beendet und hat status :" + t.ThreadState);
            
        }
        
        static void Method1()
        {
            Console.WriteLine("T: start von Methode 1");
            try
            {
                for(int i = 0; i > 1000; i++)
                {
                    Console.WriteLine("T: lopp "+i);
                    Thread.Sleep(50);//soll nicht so schnell durchlaufen
                }
            }
            catch (ThreadAbortException)
            {
                Console.WriteLine("T: in Catch");
                Thread.Sleep(20);
                //Thread.ResetAbort();//Veraltet
            }
            catch(PlatformNotSupportedException)
            {
                Console.WriteLine("HAHA");
            }
            finally
            {
                Console.WriteLine("T: im Finaly Block");
                Thread.Sleep(20);
            }
            Console.WriteLine("T: Fertig!");
        }

    }
}
