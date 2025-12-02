namespace ExeptionAufgaben
{
    public class Aufgabe1
    {
        public static double IntegerDivision(string dividend, string divisor)
        {
            int divideInt, divisorInt;
            if (string.IsNullOrEmpty(divisor))
            {
                throw new ArgumentException(
                    "Eines der übergeben Argumente ist Leer",
                    $" {nameof(divisor)}");
            }
            if (dividend == "")
            {
                throw new ArgumentException(
                    "Eines der übergeben Argumente ist Leer",
                    $"{nameof(dividend)}");
            }
            else if (!dividend.All(char.IsDigit) || !divisor.All(char.IsDigit))
            {
                throw new FormatException("Die Eingabe muss eine Zahl sein");
            }

            //Andere mögliche Fehler!!
            divideInt = Convert.ToInt32(dividend);
            divisorInt = Convert.ToInt32(divisor);
            if (divisorInt == 0)
            {
                throw new DivideByZeroException("Wir können nicht durch 0 teilen");
            }
            return divideInt / divisorInt;
        }
        public static void TuWas()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Gib die erste Zahl ein: ");
                    string erste = Console.ReadLine();
                    Console.WriteLine("Gib den Divisor ein: ");
                    string zweite = Console.ReadLine();
                    IntegerDivision(erste, zweite);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Es ist ein Fehler aufgetreten bei: " + ex.ParamName);
                    Console.WriteLine("Fehler: " + ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Es ist ein Fehler aufgetreten: ");
                    Console.WriteLine("Fehler: " + ex.Message);
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("Es ist ein Fehler aufgetreten: ");
                    Console.WriteLine("Fehler: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ein unbekannter Fehler ist aufgetreten");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
    }
}
