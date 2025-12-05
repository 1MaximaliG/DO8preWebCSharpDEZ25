using System.Collections;

namespace GenericsUndCollections
{
    public enum ABC
    {
        A, B, C
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var abc = Enum.GetNames<ABC>();//Test für SourceTree
            //Beispiele.TuWas();
            //Aufgabe00.TuWas();
            //Aufgabe01.TuWas();
            //Aufgabe02.Tuwas();
            Aufgabe03.TuWas();
        }
    }
}
