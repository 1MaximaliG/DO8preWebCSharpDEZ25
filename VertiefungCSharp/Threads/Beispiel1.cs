namespace Threads
{
    public class Beispiel1
    {
        public static void TuWas()
        {
            //Delegate
            ParameterizedThreadStart pts = new ParameterizedThreadStart(Methode1);

            Thread t1 = new Thread(pts);
            Thread t2 = new Thread(pts);

            //Start
            t1.Start("-");
            t2.Start("|");

            Methode1("*");
        }
        static void Methode1(object obj)
        {
            for (int i = 0; i < 5000; i++)
            {
                Console.Write((string)obj);
            }
        }
    }
}
