using System.Runtime.InteropServices.Swift;
using System.Runtime.Intrinsics.Arm;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Apps
{
    public class Rating
    {
        public float rate { get; set; }
        public int count { get; set; }
    }
    public class Product
    {
        //! Properties müssen genauso geschrieben werden wie in der API --> case sensitive
        //! Soll die Struktur des JSON wiederspiegeln
        public int id { get; set; }
        public string title { get; set; } = "";
        public decimal price { get; set; }
        public string description { get; set; } = "";
        public string category { get; set; } = "";
        public string image { get; set; } = "";
        public Rating rating { get; set; }

    }
    class Program
    {
        static async Task Main(string[] args)
        {
            // Endpoint von unserer API --> in diesem Fall für alle Produkte
            string url = "https://fakestoreapi.com/products";

            // HttpClient ist eine Standardklasse in .NET für http anfragen
            using HttpClient client = new();
            List<Product> productList = new();
            try
            {
                //? Inhalte der HttpResponseMessage
                //? - Statuscode (200, 201, 404, 500)
                //? - Header --> Allgemeine Infos
                //? - Body/Content --> Inhalt der API
                HttpResponseMessage response = await client.GetAsync(url); //* --> nennt sich API CALL

                response.EnsureSuccessStatusCode(); //* --> verarbeitet den StatusCode und wirft zur Not eine Exception


                string jsonData = await response.Content.ReadAsStringAsync(); //* --> Hier wird die JSON als String ausgelesen und abgelegt

                //! Hier ist jetzt wichtig das die properties aus unserer Klasse Product mit den Eigenschaften aus der JSON übereinstimmen
                //* Was passiert hier mit dem string ??? --> Erstellt jetzt aus dem String einzelne Product Objekte und packt diese in die Liste 
                productList = JsonSerializer.Deserialize<List<Product>>(jsonData);

                foreach (Product singleProduct in productList)
                {
                    System.Console.WriteLine(singleProduct.title + " " + singleProduct.price);
                    System.Console.WriteLine(singleProduct.rating.count);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            //Erstellen sie ein kleine Menü mit folgenden funktionen
            //1.) Suche nach Titel
            //2.) Produktkategorie->liste alle vorhandenen Kathegorien
            //3.) Sortiere nach Rating
            //4.) Min preis und Max Preis
            string[] mainOtions = { "Titel", "Cathegory", "Price", "Rating", "Exit" };
            Menü menü = new(mainOtions, "->");
            bool running = true;
            while (running)
            {


                switch (menü.ShowMenu())
                {
                    case 0:
                        RunSubMenu(mainOtions[0], (SearchField)0, productList);
                        break;
                    case 1:
                        RunSubMenu(mainOtions[1], (SearchField)1, productList);
                        break;
                    case 2:
                        RunSubMenu(mainOtions[2], (SearchField)2, productList);
                        break;
                    case 3:
                        RunSubMenu(mainOtions[3], (SearchField)3, productList);
                        break;

                    case 4:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Die eingabe ist falsch");
                        break;
                }
            }
        }//Ende Main
        public enum SearchField
        {
            Titel,
            Cathegory,
            Price,
            Rating
        }
        public static void Search(List<Product> liste, SearchField feld)
        {
            List<Product> matches = new();
            string query;
            if (feld == SearchField.Price)
            {
                Console.WriteLine("Enter min. Price");
            }
            else if (feld == SearchField.Rating)
            {
                Console.WriteLine("Enter min. Rating");
            }
            else
            {
                Console.WriteLine("Search Value");
            }
            query = (Console.ReadLine() ?? "").Trim();

            matches = liste.Where(p => Matches(p, feld, query)).ToList();
            foreach(var p in matches)
            {
                Console.WriteLine(p.id);
                Console.WriteLine(p.title);
                Console.WriteLine(p.category);
                Console.WriteLine(p.description);
                Console.WriteLine(p.price);
                Console.WriteLine(p.rating.rate);
                Console.WriteLine(p.rating.count);
                Console.WriteLine();
            }
            Console.ReadLine();//für anzeige warten
        }
        public static bool Matches(Product p, SearchField feld, string suche)
        {
            switch (feld)
            {
                case SearchField.Titel:
                    return p.title.Contains(suche, StringComparison.OrdinalIgnoreCase);
                case SearchField.Rating:
                    float.TryParse(suche, out float minrating);
                    return p.rating.rate >= minrating;
                case SearchField.Price:
                    decimal.TryParse(suche, out decimal maxprice);
                    return p.price <= maxprice;
                case SearchField.Cathegory:
                    return p.category.Contains(suche, StringComparison.OrdinalIgnoreCase);
                default:
                    return false;
            }
        }
        public static void RunSubMenu(string lable, SearchField field, List<Product> products)
        {
            string[] options = new string[] { $"Search {lable} :", $"All {lable}", "back" };
            bool läuft = true;
            Menü menü = new(options, "->");
            while (läuft)
            {
                switch (menü.ShowMenu())
                {
                    case 0:
                        Search(products,field);
                        break;
                    case 1:
                        foreach (var p in products)
                        {
                            Console.WriteLine(p.id);
                            Console.WriteLine(p.title);
                            Console.WriteLine(p.category);
                            Console.WriteLine(p.description);
                            Console.WriteLine(p.price);
                            Console.WriteLine(p.rating.rate);
                            Console.WriteLine(p.rating.count);
                            Console.WriteLine();
                        }
                        Console.ReadLine();
                        break;
                    default:
                        läuft = false;
                        break;
                }
            }
        }
        public class Menü
        {
            private string[] _options;
            private string _arrow;
            public Menü(string[] options, string arrow)
            {
                _arrow = arrow;
                _options = options;
            }
            public Menü(string[] options)
            {
                _options = options;
            }
            public int ShowMenu()
            {
                int index = 0;
                Console.CursorVisible = false;
                while (true)
                {
                    Console.Clear();
                    for (int i = 0; i < _options.Length; i++)
                    {
                        Console.WriteLine(i == index ? $"{_arrow} {_options[i]}" : $"   {_options[i]}");
                    }
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.UpArrow)
                    {
                        index = (index - 1 + _options.Length) % _options.Length;
                    }
                    else if (key == ConsoleKey.DownArrow)
                    {
                        index = (index + 1 + _options.Length) % _options.Length;
                    }
                    else if (key == ConsoleKey.Enter)
                    {
                        return index;
                    }
                }
            }//Ende ShowMenu
        }//Ende Menü
    }//Ende Programm
}
