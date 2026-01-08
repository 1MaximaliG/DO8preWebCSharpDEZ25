using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Serien
{
    [Serializable]
    public class Hero
    {
        public string Name;
        public Hero Partner;

        [NonSerialized]
        public string stuff;

        private int _alter;

        public Hero() { }//brauchen wir für xml
        public Hero(string name, int alter)
        {
            Name = name;
            this._alter = alter;
        }
        public int getAge()
        {
            return _alter;
        }
    }
    public class JSONHero
    {
        public string HeroName { get; set; }
        [JsonIgnore] public string FirsName { get; set; }
        [JsonIgnore] public string LastName { get; set; }
        public string Gang { get; set; }
        public JSONHero Partner { get; set; }
        public List<string> Gedgets { get; set; }
    }
    internal partial class Program
    {

        public static void XmlExample()
        {
            Hero batman = new Hero("Batman", 42);
            batman.stuff = "ABC";
            batman.Partner = new Hero("Robin", 24);
            //batman.Partner.Partner = batman;

            XmlSerializer xml = new XmlSerializer(typeof(Hero));

            using (FileStream stream = File.Create("Batman.xml"))
            {
                xml.Serialize(stream, batman);
            }
            Hero batmanCopy;
            using (FileStream stream = File.OpenRead("Batman.xml"))
            {
                batmanCopy = xml.Deserialize(stream) as Hero;
            }

            Console.WriteLine(batmanCopy.Name);
            Console.WriteLine(batmanCopy.getAge());
            Console.WriteLine(batmanCopy.Partner.Name);
            Console.WriteLine(batmanCopy.Partner.getAge());
        }
        public static void JsonExample()
        {
            JSONHero batman = new JSONHero()
            {
                HeroName = "Batman",
                FirsName = "Bruce",
                LastName = "Wayne",
                Gang = "Jusice League",
                Gedgets = new List<string>() { "Batmobil", "Batsuit", "Batarang" }
            };
            JSONHero robin = new JSONHero()
            {
                HeroName = "Robin",
                FirsName = "John",
                LastName = "Grayson",
                Gang = "Jusice League",
                Gedgets = new List<string>() { "Cape", "Roter Anzug", "Schlagstock" }
            };

            batman.Partner = robin;

            string batmanJson = JsonSerializer.Serialize(batman);
            //Console.WriteLine(batmanJson);
            //+++++++++++++++++++++++++
            string ausgabe = JsonSerializer.Serialize(batman,
                new JsonSerializerOptions
                {
                    WriteIndented = true,
                    ReferenceHandler = ReferenceHandler.Preserve
                });
            Console.WriteLine(ausgabe);
            //+++++++++++++++++++++++++++++

            JSONHero newBatman = JsonSerializer.Deserialize<JSONHero>(batmanJson);

            Console.WriteLine(newBatman.HeroName);
            Console.WriteLine(newBatman.FirsName);
            Console.WriteLine(newBatman.Gedgets[0]);
        }
        static void Main(string[] args)
        {
            //XmlExample();
            JsonExample();

        }
    }
}
