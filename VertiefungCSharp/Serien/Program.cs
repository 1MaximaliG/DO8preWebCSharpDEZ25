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
        public static void Personen01Aufgabe()
        {
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
        public class Person02
        {
            //Felder
            public string Vorname { get; set; }
            public string Nachname { get; set; }
            public DateTime Geburtsdatum { get; set; }
            public Person02 Mudder { get; set; }
            public Person02 Vadder { get; set; }
            public Person02 Blag { get; set; }

            public Person02() { }
            public Person02(string name, string nachname, DateTime geburtstag)
            {
                Vorname = name;
                Nachname = nachname;
                Geburtsdatum = geburtstag;
            }
            public override string ToString()
            {
                return Vorname + " " + Nachname + " " + Geburtsdatum.ToShortDateString();
            }
        }
        public static void Personen02Aufgabe()
        {
            //A
            List<Person02> erstellen = new List<Person02>() {
                new Person02("Bilbo","Beutlin",new DateTime(1290,9,22)),
                new Person02("James Tiberius","Kirk",new DateTime(2233,3,22)),
                new Person02("Donald","Trump",new DateTime(1946,6,14)),
                new Person02("Jong-Il","Kim",new DateTime(1941,2,16)),
                new Person02("Albus Percival Wulfric Brian","Dumbledor",new DateTime(1881,8,18))
            };
            string file = "DieListe.json";
            var options = new JsonSerializerOptions() { WriteIndented = true };
            string formatiert = JsonSerializer.Serialize(erstellen,options);
            File.WriteAllText(file,formatiert);
            erstellen = null;//Liste ist jetzt Leer
            string inhalt = File.ReadAllText(file);
            erstellen = JsonSerializer.Deserialize<List<Person02>>(inhalt);

            foreach(var p in erstellen)
            {
                Console.WriteLine(p);
            }
            //B
            Person02 eins = new Person02("Abc","A",new DateTime(1234,1,5));
            Person02 zwei = new Person02("Def", "B", new DateTime(1234, 1, 5));
            Person02 kind = new Person02("Gah", "A", new DateTime(1234, 1, 5));
            kind.Mudder = eins;
            eins.Blag = kind;
            kind.Vadder = zwei;
            zwei.Blag = kind;
            Person02 ommaA = new Person02("Ijk", "A", new DateTime(1234, 1, 5));
            eins.Mudder = ommaA;
            ommaA.Blag = eins;
            Person02 ommaB = new Person02("Lmn", "B", new DateTime(1234, 1, 5));
            zwei.Mudder = ommaB;
            ommaB.Blag = zwei;
            Person02 oppaA = new Person02("Opq", "A", new DateTime(1234, 1, 5));
            eins.Vadder = oppaA;
            oppaA.Blag = eins;
            Person02 oppaB = new Person02("Rst", "B", new DateTime(1234, 1, 5));
            oppaB.Blag = zwei;
            zwei.Vadder = oppaB;
            JsonSerializerOptions option = new JsonSerializerOptions() 
            { 
                WriteIndented = true ,
                ReferenceHandler = ReferenceHandler.Preserve
            };
            File.WriteAllText("eins.json", JsonSerializer.Serialize(eins,option));
            File.WriteAllText("zwei.json", JsonSerializer.Serialize(zwei,option));
            File.WriteAllText("drei.json", JsonSerializer.Serialize(kind,option));
            File.WriteAllText("vier.json", JsonSerializer.Serialize(ommaA,option));
            File.WriteAllText("fuenf.json", JsonSerializer.Serialize(ommaB,option));
            File.WriteAllText("sechs.json", JsonSerializer.Serialize(oppaA,option));
            File.WriteAllText("sieben.json", JsonSerializer.Serialize(oppaB,option));
            Person02 person1 = JsonSerializer.Deserialize<Person02>(File.ReadAllText("sieben.json"));
            Person02 person2 = JsonSerializer.Deserialize<Person02>(File.ReadAllText("sechs.json"));
            Console.WriteLine(person1.Blag.Blag);
            Console.WriteLine(person2.Blag.Blag);//Blag = Kind
            Console.WriteLine(person1.Blag.Blag== person2.Blag.Blag);//nicht das gleiche Objekt


        }
        static void Main(string[] args)
        {
            //XmlExample();
            //JsonExample();
            //Personen01Aufgabe();
            Personen02Aufgabe();
            

        }
    }
}
