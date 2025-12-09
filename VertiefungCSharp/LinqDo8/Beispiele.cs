namespace LinqDo8
{
    public class HeroBeispiel
    {
        // öffentliche Felder
        public string HeroName;
        public string Gang;
        public DateTime DateOfBirth;

        // privates Feld
        private string RealName;

        // parameterloser Konstruktor
        public HeroBeispiel()
        {
        }

        // Konstruktor mit Parameter
        public HeroBeispiel(string heroname)
        {
            HeroName = heroname;
        }
    }
    public static class Beispiele
    {
        public static void TuWas()
        {
            HeroBeispiel h1 = new HeroBeispiel()
            {
                HeroName = "Batman",
                Gang = " Justice League",
                DateOfBirth = new DateTime(1974, 2, 19)
            };
            Console.WriteLine(h1);
            Console.WriteLine(h1.GetType());

            //var h1short = new { h1.HeroName, h1.Gang,Geilezahl = 42 };
            var h1short = new { h1.HeroName, h1.Gang };
            var h2short = new { HeroName = "Batman", Gang = " Justice League" };
            var h3short = new { HeroName = "Batman", Gang = " Justice League" };
            //h1short.Geilezahl = 55;//geht nicht weil readonely

            Console.WriteLine(h1short);
            Console.WriteLine(h1short.GetType());
            Console.WriteLine(h2short);
            Console.WriteLine(h2short.GetType());
            Console.WriteLine(h3short);
            Console.WriteLine(h3short.GetType());


        }
    }
}
