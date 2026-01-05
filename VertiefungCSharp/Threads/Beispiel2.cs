namespace Threads
{
    internal partial class Program
    {
        public static class Beispiel2
        {
            public static  void TuWas()
            {
                /////BEispiel 2
                Thread t = new Thread(Methode1);
                t.Name = "1";
                t.IsBackground = true;
                t.Start("-");

                for (int i = 0; i < 500; i++)
                {
                    Console.Write("+");
                }

                //mit joid wartet die Main auf den Thread bevor er sich schließt
                t.Join();

                Console.WriteLine("M ended!");

            }
            static void Methode1(object obj)
            {
                for (int i = 0; i < 5000; i++)
                {
                    Console.Write((string)obj);
                }
                Console.WriteLine("T ended!");
            }
        }
 

    }
}
