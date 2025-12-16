using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DatenStreams
{
    internal class HotelService
    {
        public static void TuWas()
        {
            Console.ReadKey();
            string datei = "data_hotel.txt";
            Console.OutputEncoding = System.Text.Encoding.UTF8;//Falls kein € angezeigt werden kann
            using (StreamWriter writer = new StreamWriter("data_hotel_dm.txt"))
            {
                using (StreamReader sr = new StreamReader(datei))
                {
                    string line;
                    string[] parts;
                    while ((line = sr.ReadLine()) != null)
                    {
                        parts = line.Split(", ");
                        Console.WriteLine($"WKN: {parts[0]}");
                        parts[1] = " "+parts[1];
                        Console.WriteLine($"Euro: {parts[1]} €");
                        parts[1] = $"{Convert.ToDecimal(parts[1], CultureInfo.GetCultureInfo("en-US")) * 1.95583m:F2}";// das split bei uns mit ", " leerzeichen arbeitet brauche nwir das ',' nicht durch '.' ersetzen
                        Console.WriteLine($"Mark: {parts[1]} DM");
                        writer.WriteLine(string.Join(", ",parts));
                    }
                }
            }// datei "data_hotel.txt" wird geschlossen
            File.Move("data_hotel.txt", "data_hotel_eur.txt");
        }
        public static void TuWasA()
        {
            string datei = "data_hotel.txt";
            Console.OutputEncoding = System.Text.Encoding.UTF8;//Falls kein € angezeigt werden kann
            using (StreamReader sr = new StreamReader(datei))
            {
                string line;
                string[] parts;
                while ((line = sr.ReadLine()) != null)
                {
                    parts = line.Split(", ");
                    Console.WriteLine($"WKN: {parts[0]}");
                    //parts[1] = parts[1].Replace('.', ',');//Convertierung kann das "," nicht erkennen
                    Console.WriteLine($"Euro: {parts[1]} €");
                    //Console.WriteLine($"Mark: {(Convert.ToDecimal(parts[1]) * 1.95583m):F2} DM");
                    Console.WriteLine($"Mark: {Convert.ToDecimal(parts[1], CultureInfo.GetCultureInfo("en-US")) * 1.95583m:F2} DM");
                }
            }
        }
    }
}
