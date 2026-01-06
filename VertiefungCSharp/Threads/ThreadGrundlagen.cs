namespace Threads
{
    internal partial class Program
    {
        public class ThreadGrundlagen
        {
            //a)	Schreiben Sie eine statische Methode, die in einer for-Schleife
            //      100 mal Informationen über den aktuellen Thread ausgibt. Dazu
            //      sollen die ManagedThreadId, die Priorität und der Status des
            //      Threads gehören. Zusätzlich soll die Methode innerhalb der Schleife
            //      eine zufällige Zeit zwischen 100 und 500 Millisekunden „schlafen“.
            //      Nach Beendigung der Schleife soll die Methode dann ausgeben, dass
            //      sie das Ende erreicht hat.
            public static void MyMethodA(CancellationToken token)
            {
                Random rng = new Random();
                // e) & f)
                int x = rng.Next(0, 4);
                for (int i = 0; i < 100; i++)
                {
                    if (token.IsCancellationRequested && x % 3 == 0)
                    {
                        //Console.WriteLine($"Beende : {Environment.CurrentManagedThreadId} Status {Thread.CurrentThread.ThreadState}");
                        break;
                    }
                    Console.WriteLine($"ID:{Environment.CurrentManagedThreadId}," +
                        $"   Priorität: {Thread.CurrentThread.Priority}," +
                        $"     Status: {Thread.CurrentThread.ThreadState}");

                    Thread.Sleep(rng.Next(100, 501));
                }
                Console.WriteLine("ENDE!");
            }
            public static void TuWas()//Main
            {
                //a)
                //MyMethodA();

                //b)	Legen Sie im Hauptprogramm eine Liste von Threads an und fügen Sie
                //      dieser Liste 10 Threads hinzu, die alle Ihre Methode mit der
                //      Schleife starten. Starten Sie alle Threads in der Liste.

                //c)	Erweitern Sie das Hauptprogramm, so dass nach dem Start aller Threads
                //      ein zufälliger Thread aus der Liste ausgewählt und abgebrochen wird.
                //      Der abgebrochene Thread soll dann aus der Liste entfernt werden.
                //      Dieser Vorgang soll sich nach einer zufälligen Wartezeit zwischen 100
                //      und 500 Millisekunden solange wiederholen, bis keine Threads mehr in
                //      der Liste vorhanden sind.

                List<CancellationTokenSource> ctsList = new List<CancellationTokenSource>();
                for (int i = 0; i < 10; i++)
                {
                    ctsList.Add(new CancellationTokenSource());
                }

                List<Thread> threadList = new List<Thread>();
                for (int i = 0; i < 10; i++)
                {
                    CancellationTokenSource temp = ctsList[i];
                    threadList.Add(new Thread(() => MyMethodA(temp.Token)));
                }
                foreach (Thread t in threadList)
                {
                    t.Start();
                }
                Random rng = new Random();
                do
                {
                    int n = rng.Next(threadList.Count);

                    ctsList[n].Cancel();
                    Thread.Sleep(rng.Next(1000, 5001));
                    ctsList.RemoveAt(n);
                    //d)
                    Console.WriteLine($"Thread{threadList[n].ManagedThreadId} => {threadList[n].ThreadState}");
                    threadList.RemoveAt(n);
                } while (threadList.Count > 0);

                //d)	Erweitern Sie Ihre Methode, so dass sie im Falle eines Abbruchs von
                //      außen eine passende Meldung mit der ManagedThreadId und dem
                //      Thread - Status ausgibt.


                //e)	Erweitern Sie Ihre Methode noch einmal, so dass sie die(zufällige)
                //      Möglichkeit hat den Abbruch zu ignorieren und bis zum Ende
                //      weiterzulaufen.In diesem Fall soll am Ende wieder die Meldung
                //      ausgegeben werden, dass die Methode das Ende erreicht hat.


                //f)	Erhöhen Sie die Chance, dass die Methode den Abbruch ignoriert
                //      auf 75 %.


            }
        }
    }
}
