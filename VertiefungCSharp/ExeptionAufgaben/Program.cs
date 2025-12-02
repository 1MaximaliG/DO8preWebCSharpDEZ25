namespace ExeptionAufgaben
{
    public static class Eingabe
    {
        public static int Integer()
        {
            Console.WriteLine("Bitte eien Zahl eingeben ");
            string number = Console.ReadLine()!;
            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentException("Die Eingabe muss einen Wert haben");
            }
            if (!int.TryParse(number, out _))//alternative char.IsDigit
            {
                throw new FormatException("Die Eingabe muss eine Zahl sein");
            }
            return Convert.ToInt32(number);
        }
        public static int Integer(int min, int max)
        {
            Console.WriteLine("Bitte eien Zahl eingeben ");
            string number = Console.ReadLine()!;
            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentException("Die Eingabe muss einen Wert haben");
            }
            if (!int.TryParse(number, out _))//alternative char.IsDigit
            {
                throw new FormatException("Die Eingabe muss eine Zahl sein");
            }
            if (Convert.ToInt32(number) < min || Convert.ToInt32(number) > max)
            {
                throw new ArgumentOutOfRangeException($"Die Engabe soll im Bereich {min} - {max} liegen");
            }
            return Convert.ToInt32(number);
        }
        public static double Double()
        {
            Console.WriteLine("Bitte eien Zahl eingeben ");
            string number = Console.ReadLine()!;
            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentException("Die Eingabe muss einen Wert haben");
            }
            if (!double.TryParse(number, out _))//alternative char.IsDigit
            {
                throw new FormatException("Die Eingabe muss eine Zahl sein");
            }
            return Convert.ToDouble(number);
        }
        public static double Double(int min, int max)
        {
            Console.WriteLine("Bitte eien Zahl eingeben ");
            string number = Console.ReadLine()!;
            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentException("Die Eingabe muss einen Wert haben");
            }
            if (!double.TryParse(number, out _))//alternative char.IsDigit
            {
                throw new FormatException("Die Eingabe muss eine Zahl sein");
            }
            if (Convert.ToDouble(number) < min || Convert.ToDouble(number) > max)
            {
                throw new ArgumentOutOfRangeException($"Die Engabe soll im Bereich {min} - {max} liegen");
            }
            return Convert.ToDouble(number);
        }
        public static float Float()
        {
            Console.WriteLine("Bitte eien Zahl eingeben ");
            string number = Console.ReadLine()!;
            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentException("Die Eingabe muss einen Wert haben");
            }
            if (!float.TryParse(number, out _))//alternative char.IsDigit
            {
                throw new FormatException("Die Eingabe muss eine Zahl sein");
            }
            return Convert.ToSingle(number);
        }
        public static float Float(int min, int max)
        {
            Console.WriteLine("Bitte eien Zahl eingeben ");
            string number = Console.ReadLine()!;
            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentException("Die Eingabe muss einen Wert haben");
            }
            if (!float.TryParse(number, out _))//alternative char.IsDigit
            {
                throw new FormatException("Die Eingabe muss eine Zahl sein");
            }
            if (Convert.ToSingle(number) < min || Convert.ToSingle(number) > max)
            {
                throw new ArgumentOutOfRangeException($"Die Engabe soll im Bereich {min} - {max} liegen");
            }
            return Convert.ToSingle(number);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Aufgabe1.TuWas();
            //Aufgabe2.TuWas();
            do
            {
                try
                {
                    Eingabe.Double();
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (true);
        }
    }
}
