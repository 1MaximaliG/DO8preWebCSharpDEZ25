using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.ConstrainedExecution;

namespace Threads
{
    internal partial class Program
    {
        public class ThreadGrundlagen
        {
            public static void MyMethodA()
            {

            }
            public static void TuWas()
            {
                //a)	Schreiben Sie eine statische Methode, die in einer for-Schleife
                //      100 mal Informationen über den aktuellen Thread ausgibt. Dazu
                //      sollen die ManagedThreadId, die Priorität und der Status des
                //      Threads gehören. Zusätzlich soll die Methode innerhalb der Schleife
                //      eine zufällige Zeit zwischen 100 und 500 Millisekunden „schlafen“.
                //      Nach Beendigung der Schleife soll die Methode dann ausgeben, dass
                //      sie das Ende erreicht hat.
                Random rng = new Random();
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"ID:{},   Priorität: {},     Status: {}");
                }

                //b)	Legen Sie im Hauptprogramm eine Liste von Threads an und fügen Sie
                //      dieser Liste 10 Threads hinzu, die alle Ihre Methode mit der
                //      Schleife starten. Starten Sie alle Threads in der Liste.

                //c)	Erweitern Sie das Hauptprogramm, so dass nach dem Start aller Threads
                //      ein zufälliger Thread aus der Liste ausgewählt und abgebrochen wird.
                //      Der abgebrochene Thread soll dann aus der Liste entfernt werden.
                //      Dieser Vorgang soll sich nach einer zufälligen Wartezeit zwischen 100
                //      und 500 Millisekunden solange wiederholen, bis keine Threads mehr in
                //      der Liste vorhanden sind.

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
            //AsyncBeispiel2.TuWas();
            ThreadGrundlagen.TuWas();
        }
    }
}
