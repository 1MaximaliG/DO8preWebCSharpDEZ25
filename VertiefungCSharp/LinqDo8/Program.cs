namespace LinqDo8
{
    class Hero
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HeroName { get; set; }
        public string Gang { get; set; }
        private DateTime dateOfBirth;

        public void SetDateOfBirth(DateTime d)
        {
            dateOfBirth = d.Date;
        }

        public int GetAge()
        {
            if (dateOfBirth >= DateTime.Today)
                return 0;
            int age = DateTime.Today.Year
                - dateOfBirth.Year;
            if (dateOfBirth.AddYears(age)
                > DateTime.Today)
                age--;
            return age;
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                //Beispiele.TuWas();
                //Aufgabenblatt1.TuWas();
                Aufgabenblatt2.TuWas();


                //List<Hero> heroes = new List<Hero>
                //{

                //    new Hero { FirstName = "Scott", LastName = "Summers", HeroName = "Cyclops", Gang = "X-Men1" },
                //    new Hero { FirstName = "Jean", LastName = "Grey", HeroName = "Phoenix", Gang = "X-Men" },
                //    new Hero { FirstName = "Logan", LastName = "Howlett", HeroName = "Wolverine", Gang = "X-Men1" },
                //    new Hero { FirstName = "Ororo", LastName = "Munroe", HeroName = "Storm", Gang = "X-Men" },
                //    new Hero { FirstName = "Kurt", LastName = "Wagner", HeroName = "Nightcrawler", Gang = "X-Men1" },
                //    new Hero { FirstName = "Raven", LastName = "Darkhölme", HeroName = "Mystique", Gang = "X-Men" },
                //    new Hero { FirstName = "Charles", LastName = "Xavier", HeroName = "Professor X", Gang = "X-Men" },
                //    new Hero { FirstName = "Anna", LastName = "Marie", HeroName = "Rogue", Gang = "X-Men2" },
                //    new Hero { FirstName = "Piotr", LastName = "Rasputin", HeroName = "Colossus", Gang = "X-Men2" },
                //    new Hero { FirstName = "Bobby", LastName = "Drake", HeroName = "Iceman", Gang = "X-Men2" }
                //};
                ////Linq beispiele
                ////Query Experssion
                //var xmen = 
                //    from hero in heroes
                //    where hero.Gang == "X-Men"
                //    select hero.HeroName;

                //foreach(var x in xmen)
                //{
                //    Console.WriteLine(x);
                //}
                ////Extension Expression
                //Console.WriteLine( "+++++++++++++++");
                //var xmen2 =
                //    heroes
                //    .Where(hero => hero.Gang == "X-Men")
                //    .Select(hero => hero.HeroName);

                //foreach (var x in xmen2)
                //{
                //    Console.WriteLine(x);
                //}
                //Console.WriteLine( "---------------------------");
                //string[] words = { "Hallo", "Linq" };
                //int[] zahlen = { 1, 22, 464363, 124156137 };

                //var sortlängen = words.Select(word => word);
                //foreach(var s in sortlängen)
                //{
                //    Console.WriteLine(s);
                //}

                //var abc = words.SelectMany(word => word);
                ////var eins = zahlen.SelectMany(s => s);//gibt schon einen Compilerfehler
                //foreach (var s in abc)
                //{
                //    Console.WriteLine(s);
                //}
                ////Skip/Take
                //List<int> numbers = Enumerable.Range(1, 50).ToList();

                //int page = 3;
                //int size = 10;

                //var pagenumbers = numbers
                //    .Skip((page - 1) * size)
                //    .Take(size);

                //foreach (var s in pagenumbers)
                //{
                //    Console.WriteLine(s);
                //}

                ////GoupBy
                //Console.WriteLine("---------------------------------");
                //var groupedByGang = 
                //    heroes
                //    .GroupBy(hero => hero.Gang);
                //foreach(var gang in groupedByGang)
                //{
                //    Console.WriteLine(gang.Key);
                //    foreach(var hero in gang)
                //    {
                //        Console.Write("- ");
                //        Console.WriteLine(hero.HeroName);
                //    }
                //}
                ////var hero4 = heroes.ElementAt(4);
                //var hero4 = heroes.ElementAtOrDefault(10);
                //Console.WriteLine(hero4 == null);

                //// Verzögerte ausführung
                //var even1numers = numbers.Where(n => n % 2 == 0);
                //var even2numers = even1numers.ToList();

                //numbers.Clear();
                //foreach (int n in even1numers)
                //{
                //    Console.WriteLine(n);
                //}


                //foreach(int n in even2numers)
                //{
                //    Console.WriteLine(n);
                //}
            }
        }
    }
}
