namespace Threads
{
    internal partial class Program
    {
        public class BeispielCancel
        {
            public static void TuWas()
            {
                //für neue Variante mit CancelToken
                var cts = new CancellationTokenSource();
                //Thread t = new Thread(Method1());
                Thread t = new Thread(() => Method1(cts.Token));//Methode mit Token übergeben
                t.Start();
                Console.WriteLine("M: hinter Thread Start");
                Thread.Sleep(5000);
                Console.WriteLine("M: vor Abbruch");
                //Abort worft nach dem catch automatisch wieder einer ThreadAbortException geworfen, was es fast unmöglich macht hier wieder elegant raus zu kommen
                //t.Abort();
                cts.Cancel();

                Console.WriteLine("M: nach Abbruchaufforderung");

                t.Join(); // warten auf beenden des Threads
                Console.WriteLine("M: T ist beendet und hat status :" + t.ThreadState);
            }
            //static void Method1()
            static void Method1(CancellationToken ct)
            {
                Console.WriteLine("T: start von Methode 1");
                try
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        if (ct.IsCancellationRequested)
                        {
                            //ergänzug für CancelationToken
                            Console.WriteLine("T: Abbruch wurde angefragt");
                            break;
                        }
                        Console.WriteLine("T: lopp " + i);
                        Thread.Sleep(500);//soll nicht so schnell durchlaufen
                    }
                }
                //catch (ThreadAbortException)
                catch (OperationCanceledException)
                {
                    Console.WriteLine("T: in Catch");
                    Thread.Sleep(200);
                    //Thread.ResetAbort();//Veraltet
                }
                finally
                {
                    Console.WriteLine("T: im Finaly Block");
                    Thread.Sleep(200);
                }
                Console.WriteLine("T: Fertig!");
            }
        }



    }
}
