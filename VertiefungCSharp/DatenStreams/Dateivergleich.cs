namespace DatenStreams
{
    internal class Dateivergleich
    {
        //Aufgabe A
        public static void TuWasA()
        {
            //Erstellen von zwei Dateien mit unterschiedlischen Inhalten
            string FileName = "Test1.txt";
            FileStream fs = File.Create(FileName);

            //Text in erste Datei
            using StreamWriter sw = new StreamWriter(fs);//ohne scope {} steht der Streamwriter in der ganzen Methode zur verfügung
            sw.WriteLine("EIN UNERWARTETES FEST");
            sw.WriteLine("In einem Loch im Boden, da lebte ein Hobbit.");
            sw.WriteLine("Nicht in einem feuchten, schmutzigen Loch, wo es nach Moder riecht und Wurmzipfel von den Wänden herabhängen, und auch nicht in einer trockenen, kahlen Sandgrube ohne Tische und Stühle, wo man sich zum Essen hinsetzen kann:");
            sw.WriteLine("Nein, das Loch war eine Hobbithöhle, und das heißt, es war sehr komfortabel.");
            sw.WriteLine("Die Tür war kreisrund wie ein Bullauge, grün gestrichen, mit einem blanken gelben Messingknopf genau in der Mitte.");
            sw.WriteLine("Sie führte in eine röhrenförmige Diele, eine Art Tunnel, aber ein sehr komfortabler, luftiger Tunnel mit holzgetäfelten Wänden, gekacheltem und mit Teppichen belegtem Fußboden, lackierten Stühlen und einer Unmenge Haken an der Wand für Hüte und Mäntel – der Hobbit hatte gern Besuch.");
            sw.Close(); //kann durch using weggelassen werden

            FileName = "Test2.txt";//gleicher Text
            FileStream fs2 = File.Create(FileName);
            StreamWriter sw2 = new StreamWriter(fs2);
            sw2.WriteLine("EIN UNERWARTETES FEST");
            sw2.WriteLine("In einem Loch im Boden, da lebte ein Hobbit.");
            sw2.WriteLine("Nicht in einem feuchten, schmutzigen Loch, wo es nach Moder riecht und Wurmzipfel von den Wänden herabhängen, und auch nicht in einer trockenen, kahlen Sandgrube ohne Tische und Stühle, wo man sich zum Essen hinsetzen kann:");
            sw2.WriteLine("Nein, das Loch war eine Hobbithöhle, und das heißt, es war sehr komfortabel.");
            sw2.WriteLine("Die Tür war kreisrund wie ein Bullauge, grün gestrichen, mit einem blanken gelben Messingknopf genau in der Mitte.");
            sw2.WriteLine("Sie führte in eine röhrenförmige Diele, eine Art Tunnel, aber ein sehr komfortabler, luftiger Tunnel mit holzgetäfelten Wänden, gekacheltem und mit Teppichen belegtem Fußboden, lackierten Stühlen und einer Unmenge Haken an der Wand für Hüte und Mäntel – der Hobbit hatte gern Besuch.");
            sw2.Close();

            FileName = "Test3.txt";//anderer Text
            FileStream fs3 = File.Create(FileName);
            sw2 = new StreamWriter(fs3); //sw2 kann wiederverwendet werden, wenn der alte geschlossen wurde
            sw2.WriteLine("Die Diele zog sich in Windungen ein ganzes Stück weit hin, aber nicht tief in den Bühl hinein – so wurde die kleine Anhöhe von den Nachbarn auf etliche Meilen im Umkreis genannt –, und viele kleine runde Türen gingen darauf hinaus, abwechselnd zu beiden Seiten.");
            sw2.WriteLine("Treppen brauchte der Hobbit nicht zu steigen: Schlafzimmer, Bad, Keller, Speisekammern (deren er mehrere hatte), Garderoben (ganze Kammern voller Kleider), die Küche und die Speisezimmer, alles lag auf gleicher Höhe und grenzte an diesen Gang.");
            sw2.WriteLine("Die besten Zimmer waren auf der linken Seite (wenn man hereinkam), denn nur hier gab es Fenster, tief über dem Boden angesetzte runde Fenster, aus denen der Hobbit auf seinen Garten und die zum Fluss abfallenden Wiesen dahinter hinaussah.");
            sw2.WriteLine("Dieser Hobbit war ein sehr wohlhabender Hobbit, und er hieß Beutlin.");
            sw2.Close();

            //Text aus Datei einlesen
            string eins;
            string zwei;
            using (StreamReader stream1 = File.OpenText("Test1.txt"), stream2 = File.OpenText("Test3.txt"))
            {
                eins = stream1.ReadToEnd();
                zwei = stream2.ReadToEnd();
            }
            //if(String.Equals(eins, zwei, StringComparison.OrdinalIgnoreCase))
            if (eins == zwei)
            {
                Console.WriteLine("sind gleich");
            }
            else
            {
                Console.WriteLine("sind nicht gleich");
            }
           

        }
        //Aufgabe B
        public static void TuWasB()
        {
            string eins = "Test1.txt";
            string zwei = "Test2.txt";
            string drei = "Test3.txt";
            StreamReader sr1 = File.OpenText(eins);
            StreamReader sr2 = File.OpenText(drei);
            string? line1;
            string? line2;
            int linecounter = 0;
            //while((line1 = sr1.ReadLine()) != null && (line2 = sr2.ReadLine()) != null)//Funktioniert nur wenn Zeilenanzahl gleich ist
            //while (!((line1 = sr1.ReadLine()) == null & (line2 = sr2.ReadLine()) == null))//Valide Lösung!
            while(true)
            {
                line1 = sr1.ReadLine();
                line2 = sr2.ReadLine();
                if(line1 == null ^ line2 == null)
                {
                    Console.WriteLine("Eine Datei ist länger als die andere");
                    break;
                }
                if(line1 == null && line2 == null)
                {
                    Console.WriteLine("Die Dateien sind gleich");
                    break;
                }


                linecounter++;
                if(line1 != line2)
                {
                    Console.WriteLine($"Es gibt Abweichung in Zeile: {linecounter}");
                    break;
                }
            }
            sr2.Close();
            sr1.Close();
        }
        public static void TuWasC()
        {
            string eins = "Test1.txt";
            string zwei = "Test2.txt";
            string drei = "Test3.txt";
            StreamReader sr1 = File.OpenText(eins);
            StreamReader sr2 = File.OpenText(drei);
            string? line1;
            string? line2;
            int linecounter = 0;
            int fehlerCounter = 0;
            //while((line1 = sr1.ReadLine()) != null && (line2 = sr2.ReadLine()) != null)//Funktioniert nur wenn Zeilenanzahl gleich ist
            //while (!((line1 = sr1.ReadLine()) == null & (line2 = sr2.ReadLine()) == null))//Valide Lösung!
            while (true)
            {
                line1 = sr1.ReadLine();
                line2 = sr2.ReadLine();
                if (line1 == null ^ line2 == null)
                {
                    Console.WriteLine("Eine Datei ist länger als die andere");
                    fehlerCounter ++;
                }
                if (line1 == null && line2 == null)
                {
                    Console.WriteLine("Die Dateien sind gleich");
                    break;
                }


                linecounter++;
                if (line1 != line2)
                {
                    Console.WriteLine($"Es gibt Abweichung in Zeile: {linecounter}");
                    fehlerCounter++;
                }
            }
            sr2.Close();
            sr1.Close();
        }
    }
}
