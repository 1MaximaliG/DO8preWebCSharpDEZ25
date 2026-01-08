using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Serien
{
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
        public class Person
        {
            public string VorName { get; set; }
            public string NachName { get; set; }
            public int Alter { get; set; }
        }
        public static void Laden()
        {
            Console.WriteLine("Welche Person soll geladen werden?");
            string eingabe = Console.ReadLine().Replace(" ", "");
            string file = eingabe + ".txt";
            if (File.Exists(file))
            {
                string inhalt = File.ReadAllText(file);
                Person x = JsonSerializer.Deserialize<Person>(inhalt);
                Console.WriteLine("Vorname: " + x.VorName);
                Console.WriteLine("Nachname: " + x.NachName);
                Console.WriteLine("Alter: " + x.Alter);
            }
            else
            {
                Console.WriteLine(file + " exisitiert nicht!!!");
            }

        }
        public static void Speichern()
        {
            Person a = new Person();
            Console.WriteLine("Bitte gib einen Vornamen ein");
            a.VorName = Console.ReadLine();
            Console.WriteLine("Bitte gib einen Nachnamen ein");
            a.NachName = Console.ReadLine();
            Console.WriteLine("Bitte gib das Alter ein");
            a.Alter = Convert.ToInt32(Console.ReadLine());
            string file = a.VorName + a.NachName + ".txt";
            var options = new JsonSerializerOptions();
            options.WriteIndented = true;
            string serialisiertePerson = JsonSerializer.Serialize(a, options);

            File.WriteAllText(file, serialisiertePerson);
        }
        static void Main(string[] args)
        {
            //XmlExample();
            //JsonExample();
            while (true)
            {
                Console.WriteLine("1: Laden");
                Console.WriteLine("2: Speichern");
                Console.WriteLine("3: Beenden");
                Console.Write("Eingabe: ");
                string eingabe = Console.ReadLine();
                switch (eingabe)
                {
                    case "1":
                        Laden();
                        break;
                    case "2":
                        Speichern();
                        break;
                    case "3":
                        //Beenden
                        return;//Beendet hier die Main Methode
                    default:
                        Console.WriteLine("invalide eingabe");
                        break;
                }
            }

        }
    }
}
