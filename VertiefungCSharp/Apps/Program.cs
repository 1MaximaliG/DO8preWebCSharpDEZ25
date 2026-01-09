using System.Runtime.Intrinsics.Arm;
using System.Text.Json;
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
                List<Product> productList = JsonSerializer.Deserialize<List<Product>>(jsonData);

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
        }
    }

}
