namespace Delegaten
{

    internal class Program
    {
        public static void methode(string m)
        {
            Console.WriteLine("Hallo "+ m);
        }
        static void Main(string[] args)
        {
            //Beispiel1.TuWas();
            //Beispiel2.TuWas();
            //Aufgabe1.TuWas();
            //ArrayFilterAufgabe.TuWas();
            //StringBearbeiten.TuWas();
            //MitarbeiterVerwaltung.TuWas();
            Action<string> sagMAlHallo = (string m) => { Console.WriteLine("Hallo " + m); } ;
            Action<string> sagMalHallo2 = methode;
            sagMAlHallo("Max");
        }
    }
}
