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
                List<Hero> heroes = new List<Hero>
                {

                    new Hero { FirstName = "Scott", LastName = "Summers", HeroName = "Cyclops", Gang = "X-Men" },
                    new Hero { FirstName = "Jean", LastName = "Grey", HeroName = "Phoenix", Gang = "X-Men" },
                    new Hero { FirstName = "Logan", LastName = "Howlett", HeroName = "Wolverine", Gang = "X-Men" },
                    new Hero { FirstName = "Ororo", LastName = "Munroe", HeroName = "Storm", Gang = "X-Men" },
                    new Hero { FirstName = "Kurt", LastName = "Wagner", HeroName = "Nightcrawler", Gang = "X-Men" },
                    new Hero { FirstName = "Raven", LastName = "Darkhölme", HeroName = "Mystique", Gang = "X-Men" },
                    new Hero { FirstName = "Charles", LastName = "Xavier", HeroName = "Professor X", Gang = "X-Men" },
                    new Hero { FirstName = "Anna", LastName = "Marie", HeroName = "Rogue", Gang = "X-Men" },
                    new Hero { FirstName = "Piotr", LastName = "Rasputin", HeroName = "Colossus", Gang = "X-Men" },
                    new Hero { FirstName = "Bobby", LastName = "Drake", HeroName = "Iceman", Gang = "X-Men" }
                };
            //Beispiele.TuWas();
        }
    }
}
