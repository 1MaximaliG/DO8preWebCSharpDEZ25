using System.Text;
using StringExtensionAufgaben;//möglich nach hinzufügen des Projekt verweises

namespace StringExtensionAufgaben
{
    public static class StringExtension
    {
        public static int CountCharInString(this string s, char c)
        {
            s = s.ToUpper();
            c = char.ToUpper(c);
            int counter = 0;
            foreach (char buchstabe in s)
            {
                if (buchstabe == c)
                {
                    counter++;
                }
            }
            return counter;
        }
        public static void AnalyseString(this string s)
        {
            int vokale = 0;
            int umlaute = 0;
            int konsonanten = 0;
            int zahlen = 0;
            int rest = 0;
            string vokal = "aeiou";
            string umlaut = "äöüß";
            string konsonant = "qwrtzplkjhgfdsyxcvbnm";
            string zahl = "0123456789";
            foreach (char c in s)
            {
                char a = char.ToLower(c);
                if (vokal.Contains(a))
                {
                    vokale++;
                }
                else if (umlaut.Contains(a))
                {
                    umlaute++;
                }
                else if (konsonant.Contains(a))
                {
                    konsonanten++;
                }
                else if (zahl.Contains(a))
                {
                    zahlen++;
                }
                else
                {
                    rest++;
                }
                //switch (a)
                //{
                //    case 'a' or 'e' or 'i' or 'o' or 'u': 
                //        vokale++; 
                //        break;
                //    case char ch when konsonant.Contains(ch): 
                //        konsonanten++; 
                //        break;
                //    case char ch when char.IsNumber(ch): 
                //        zahlen++; 
                //        break;
                //    case char ch when char.IsLetter(ch): //reicht hier, da wir Vokale und Konsonanten schon abgefangen haben!
                //        umlaute++; 
                //        break;
                //    default: 
                //        rest++; 
                //        break;
                //}
            }
            Console.WriteLine("Vokale: ".PadRight(15) + vokale);
            Console.WriteLine("Konsonanten: ".PadRight(15) + konsonanten);
            Console.WriteLine("Umlaute: ".PadRight(15) + umlaute);
            Console.WriteLine("Zahlen: ".PadRight(15) + zahlen);
            Console.WriteLine("Sonstige: ".PadRight(15) + rest);
        }
        public static bool IsPalindrom(this string s)
        {
            s = s.ToLower().Replace(" ", "");
            char[] chararray = s.ToCharArray();
            Array.Reverse(chararray);
            string b = new string(chararray);
            return s.Equals(b);
        }
        public static bool IsPalindromAlt(this string s)
        {
            s = s.ToLower();
            char[] chararray = s.ToCharArray();
            Array.Reverse(chararray);
            string b = new string(chararray);
            return s.Equals(b);
        }
        public static bool ContainsDuplicateChars(this string s)
        {
            char[] textToCharArray = s.ToLower().ToCharArray();
            Array.Sort(textToCharArray);
            for (int i = 0; i < s.Length - 2; i++)
            {
                if (textToCharArray[i] == textToCharArray[i + 1])
                {
                    return true;
                }
            }
            return false;
        }
        public static bool ContainsDuplicateChars2(this string s)
        {
            bool isDouble = false;
            s = s.ToLower();
            string suchen = "";
            for (int i = 0; i < s.Length; i++)
            {
                suchen = suchen.Insert(i, Convert.ToString(s[i]));
                s = s.Remove(i, 1);
                foreach (char ch in suchen)
                {
                    if (s.Contains(ch))
                    {
                        isDouble = true;
                    }
                }
            }
            return isDouble;
        }
        public static string RemoveDuplicateChars(this string s)
        {
            string text = s.ToLower();
            string result = string.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                if (!result.Contains(text[i]))
                {
                    result += text[i];
                }
            }
            return result;
        }
        public static string Capitalize(this string s)
        {
            bool IsCapital = true;
            string antwort = string.Empty;//gerne auch mit StringBuilder
            foreach (char c in s)
            {
                if (c == ' ')
                {
                    antwort += c;
                    IsCapital = true;
                }
                else if (IsCapital)
                {
                    antwort += char.ToUpper(c);
                    IsCapital = false;
                }
                else
                {
                    antwort += char.ToLower(c);
                }
            }
            return antwort;
        }
        public static string Capitalize(this string s, Char[] chars)
        {
            bool IsCapital = true;
            StringBuilder antwort = new StringBuilder();
            foreach (char c in s)
            {
                if (chars.Contains(c))
                {
                    antwort.Append(c);
                    IsCapital = true;
                }
                else if (IsCapital)
                {
                    antwort.Append(char.ToUpper(c));
                    IsCapital = false;
                }
                else
                {
                    antwort.Append(char.ToUpper(c));
                }
            }
            return antwort.ToString();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!".CountCharInString('o'));
            Console.WriteLine("Hello, World!".IsPalindrom());
        }
    }
}
