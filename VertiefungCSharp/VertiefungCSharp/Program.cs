using System.Diagnostics;
using System.Text;

namespace VertiefungCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            s = new string('#', 100);
            Console.WriteLine(s);
            Stopwatch watch = new Stopwatch();
            char[] wort = { 'H', 'A', 'L', 'L', 'O' };
            s = new string(wort);
            Console.WriteLine(s);
            watch.Start();
            for (int i = 0; i < 100000; i++)
            {
                s += "x";
            }
            watch.Stop();
            Console.WriteLine("Zeit: " + watch.ElapsedMilliseconds);
            watch.Reset();

            StringBuilder sb = new StringBuilder();
            watch.Start();
            for (int i = 0; i < 100000; i++)
            {
                sb.Append("x");
            }
            //Funktionen:
            //Append
            //Insert
            //Remove
            //Replace
            //Char -> auswahl der Buchstaben über indexe sb[]
            //Length
            //Capacity - gibt an wie groß der String werden darf bevor neuer speicher notwendig ist
            watch.Stop();
            Console.WriteLine("Zeit: " + watch.ElapsedMilliseconds);
            Console.WriteLine("Länge: " + sb.Length);
            char x = s[4];
            Console.WriteLine(x);
            //suchfunktionen
            s.StartsWith("Hallo");//liefert true
            //EndsWith  - wie StartsWith nur von hinten
            //IndexOf   - gibt den ersten index mit übereinstimmung
            //SubString - gibt einen teil zwischen zwei indexen aus
            string teststring = "***+Hello World ##+***";
            teststring = teststring.Trim('*', '+', '#');//gibt es auch als TrimStart/TrimEnd
            Console.WriteLine(teststring);
            teststring = teststring.PadLeft(teststring.Length + 3, '*');
            Console.WriteLine(teststring);//Auffüllen mit angegebenen Symbol
            teststring = teststring.Insert(4, "ABC");
            Console.WriteLine(teststring);
            teststring = teststring.Remove(4, 3);//lösche 3 buchstaben ab index 4
            Console.WriteLine(teststring);
            teststring = "***+Hello ******* World ##+***";
            teststring = teststring.Replace('*', ' ');
            Console.WriteLine(teststring);
            string[] sarray = teststring.Split(' ');
            foreach (string a in sarray)
            {
                Console.WriteLine("Zeile =" + a);
            }
            int zahl = 123;
            decimal pie = 3.1419m;
            decimal money = 111114.9999999m;
            string tst = "akshfa";
            Console.WriteLine($"-->>>{teststring}<<<___");
            Console.WriteLine("kjhsgshs  {0} - {1}",tst,zahl);
            Console.WriteLine("kjhsgshs  {0,3:F} - {1,20:C4}", pie, money);//{index [,breite][:Format]}
            string link = "00_M.Gron\\10_Kursvorlagen\\50_Programieren in C#\\10_Themen";
            //Verbatim String
            string vlink = @"00_M.Gron\10_Kursvorlagen\50_Programieren in C#\10_Themen";//interpretiert kein / nur noch "
            string ordner1 = "Testordner";
            string combi = $@"ajhsfhakhfa\{ordner1}
            jgls        kjglsjgl";//verbatm kann über zeilenhinweg arbeiten
        }
    }
}
