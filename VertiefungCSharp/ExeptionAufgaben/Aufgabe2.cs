using System.Text;

namespace ExeptionAufgaben
{
    public class ArgumentFormatException : Exception
    {
        public ArgumentFormatException() { }
        public ArgumentFormatException(string message) : base(message) { }
        public ArgumentFormatException(string message, Exception inner) : base(message, inner) { }
    }
    public static class ISBNStringExtension
    {
        public static string ToISBN(this string isbn)
        {
            if (string.IsNullOrEmpty(isbn))
            {
                throw new ArgumentNullException($"die Varibale{nameof(isbn)} ist null ode leer");
            }
            if (!isbn.All(char.IsDigit))
            {
                throw new ArgumentFormatException("Es sollen nur Zahlen im String sein");
            }
            if (isbn.Length != 13)
            {
                throw new ArgumentOutOfRangeException($"der übergebene string <{isbn}> hat nicht die Länge 13");
            }
            string neu;
            StringBuilder sb = new StringBuilder(isbn);
            sb.Insert(12, '-');
            sb.Insert(9, '-');
            sb.Insert(4, '-');
            sb.Insert(3, '-');
            return "ISBN " + sb.ToString();
            //neu = "ISBN "+isbn.Substring(0, 3) + "-" 
            //+ isbn.Substring(3, 1) + "-" 
            //+ isbn.Substring(4, 5) + "-" 
            //+ isbn.Substring(9, 3) + "-" 
            //+ isbn.Substring(12);
            //return neu;
        }
    }
    public class Aufgabe2
    {
        public static void TuWas()
        {
            string s = "1234567890123";//13 stellen
            //s = string.Empty;
            try
            {
                Console.WriteLine(s.ToISBN());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
