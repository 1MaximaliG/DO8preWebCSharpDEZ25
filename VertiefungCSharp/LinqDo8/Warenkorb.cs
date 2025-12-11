namespace LinqDo8
{
    public class Warenkorb
    {
        public static void Tuwas()
        {
            Kunde[] kunden = Kunde.GetKundenListe();
            Produkt[] produkte = Produkt.GetProduktListe();

            var kundennamen =
                from k in kunden
                select k.Name;

            foreach (var name in kundennamen)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("Fertig!");
            // powered by https://github.com/calvinkreitmeier-dot
            //a)Selektieren Sie nur die Namen aller Produkte und anschließend nur Name und Wohnort aller Kunden aus den beiden Arrays.
            var kundennamen1 = kunden.Select(kunde => (kunde.Name, kunde.Ort));
            //b)Selektieren Sie die Bestellungen aller Kunden aus Deutschland.
            var deutschebestellungen = kunden.Where(kunde => kunde.Land == Länder.Germany).Select(kunde => kunde);
            //c)Selektieren Sie nur den Namen für jeden zweiten Kunden, beginnend mit dem ersten.
            var jederzweite = kunden.Where((kunde, idx) => idx % 2 == 1);
            //d)Selektieren Sie nur Name und Preis aller Produkte, die höchstens 20 Euro kosten. Das Ergebnis soll absteigend nach dem Preis sortiert sein.
            var sortiertunter20 = produkte.Where(produkt => produkt.Preis < 20).OrderByDescending(produkt => produkt.Preis);
            // e)	Selektieren Sie nur Name und Land aller Kunden. Das Ergebnis soll aufsteigend nach dem Land sortiert werden. Bei gleichem Land sollen die Kunden nach dem Namen sortiert werden.
            var namelandsort = kunden.OrderBy(kunde => kunde.Land).ThenBy(kunde => kunde.Name);
            // f)	Gruppieren Sie die Kunden nach dem Land. Als Gruppenelement soll jeweils das gesamte Kunden-Objekt verwendet werden.
            var grouplands = kunden.GroupBy(kunde => kunde.Land);
            // g)	Gruppieren Sie die Produkte nach dem ersten Buchstaben des Namens. Als Elemente in den Gruppen sollen nur die Namen der Produkte vorhanden sein.
            var nameprodukt = produkte.GroupBy(produkt => produkt.Name[0]).Select(gruppe => gruppe.Select(prod => prod.Name));
            // h)	Bilden Sie einen Join zwischen den Bestellungen und den Produkten. Selektieren Sie dann die Werte für Monat, ProduktNr, Name, Preis und Versendet sortiert nach dem Preis.
            var joinall = from kunde in kunden // Selektiert Kunden
                          from bestellung in kunde.Bestellungen // Selektiert die Bestellungen der Kunden
                          join prod in produkte on // Gibt an, dass Produkte auf die Bestellungen gejoint werden
                          bestellung.ProduktNr equals prod.ProduktNr
                          select new // Gibt an, dass die Produktnummer der Bestellung mit der Produktnummer der Produkte vergleichen werden soll
                          {
                              daten = @$"Name: {prod.Name}, 
        @Produkt ID: {bestellung.ProduktNr}, 
        Anzahl: {bestellung.Anzahl}, 
        Preis: {prod.Preis}, 
        Monat: {bestellung.Monat}, 
        Versendet?: {bestellung.Versendet}" // Gibt die in der Aufgabe geforderten Daten in einem String wieder, welcher mit joinall.daten aufgerufen werden kann.
                          };
            // i)	Selektieren Sie alle Kunden mit Name, Wohnort und Anzahl Bestellungen.
            var datenkunden = kunden.Select(kunde => (kunde.Name, kunde.Ort, kunde.Bestellungen.Length));
            // j)	Summieren Sie die Preise aller Produkte aus der Produktliste.
            var allepreise = produkte.Select(prod => prod.Preis);
            // k)	Selektieren Sie alle Kunden mit ihrem Namen und dem Gesamtbetrag ihrer Bestellungen.
            var preisprokunde = from kunde in kunden // Selektiert die Kunden aus
                                from bestellung in kunde.Bestellungen // Selektiert die Bestellungen der Kunden
                                join prod in produkte on //Gibt an, dass Produkte auf die Bestellungen gejoint werden
                                bestellung.ProduktNr equals prod.ProduktNr
                                group new { kunde, bestellung, prod } // Vergleicht die Produktnummern und gibt diese als Gruppe zurück
                                by kunde.Name into gruppe
                                select new // Gibt an, dass die oben zurückgegeben Gruppen als nach Kundennamen Gruppiert werden
                                {
                                    daten = $"Name: {gruppe.Key} Gesamtbetrag der Bestellungen: {gruppe.Sum(x => x.bestellung.Anzahl * x.prod.Preis)}"
                                };// Gibt die in der Aufgabe geforderten Daten in einem String wieder, fertig addiert

            foreach (var kunde in kundennamen1) { System.Console.WriteLine(kunde.ToString()); }
            System.Console.WriteLine();
            foreach (var kunde in deutschebestellungen) { System.Console.WriteLine(kunde.ToString()); }
            System.Console.WriteLine();
            foreach (var kunde in jederzweite) { System.Console.WriteLine(kunde.ToString()); }
            System.Console.WriteLine();
            foreach (var produkt in sortiertunter20) { System.Console.WriteLine(produkt.Name + " " + produkt.Preis); }
            System.Console.WriteLine();
            foreach (var kunde in namelandsort) { System.Console.WriteLine(kunde.Land + " " + kunde.Name); }
            System.Console.WriteLine();
            foreach (var gruppe in grouplands) { System.Console.WriteLine($"Land: {gruppe.Key}"); foreach (var kunde in gruppe) System.Console.WriteLine(kunde.ToString()); }
            System.Console.WriteLine();
            foreach (var group in nameprodukt) { System.Console.WriteLine($"Anfangsbuchstabe: {group.First()[0]}"); foreach (var name in group) System.Console.WriteLine(name); }
            System.Console.WriteLine();
            foreach (var item in joinall) { System.Console.WriteLine(item.daten); }
            System.Console.WriteLine();
            foreach (var (Name, Ort, Length) in datenkunden) System.Console.WriteLine($"Name: {Name} Ort: {Ort}, Anzahl der Bestellungen: {Length}");
            System.Console.WriteLine();
            System.Console.WriteLine($"Der Preis aller Produkte liegt bei: {allepreise.Sum()}");
            System.Console.WriteLine();
            foreach (var kunde in preisprokunde) System.Console.WriteLine(kunde.daten);
            //test

        }
    }
}
