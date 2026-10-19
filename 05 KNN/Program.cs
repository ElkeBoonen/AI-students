namespace _05_KNN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            // ===== BLOK 1: afstanden =====
            KNN rooster = new KNN("rooster.csv");
            double[] x = { 5, 3, 4 };
            double[] y = { 3, 1, 2 };
            Console.WriteLine("BLOK 1");
            Console.WriteLine("Euclidisch: " + Math.Round(rooster.Distance(x, y), 3) + "   (verwacht 3.46)");
            Console.WriteLine("Manhattan:  " + Math.Round(rooster.Manhattan(x, y), 3) + "   (verwacht 6)");

            // ===== BLOK 2: sorteren en stemmen =====
            Console.WriteLine();
            Console.WriteLine("BLOK 2");
            double[] nieuwPunt = { 5, 5 };
            Console.WriteLine("Rooster k = 1: " + rooster.Classify(nieuwPunt, 1) + "   (verwacht A)");
            Console.WriteLine("Rooster k = 3: " + rooster.Classify(nieuwPunt, 3) + "   (verwacht B)");

            KNN klanten = new KNN("klanten.csv");
            double[] nieuweKlant = { 24, 420 };   // 24 jaar, 420 minuten per week
            Console.WriteLine("Nieuwe klant k = 3: " + klanten.Classify(nieuweKlant, 3));

            // ===== BLOK 3: normalisatie =====
            Console.WriteLine();
            Console.WriteLine("BLOK 3");
            klanten.Normalize();
            double[] geschaald = klanten.Scale(nieuweKlant);
            Console.WriteLine("Geschaald: " + Math.Round(geschaald[0], 2) + ", " + Math.Round(geschaald[1], 2) + "   (verwacht 0.11, 0.49)");
            Console.WriteLine("Nieuwe klant k = 3: " + klanten.Classify(geschaald, 3) + "   (verwacht actie)");

            // ===== BLOK 4: cosine en aanbevelingen (cursus 5.6.3) =====
            Console.WriteLine();
            Console.WriteLine("BLOK 4");
            double[] gebruikerX = { 4, 2, 5, 3 };
            double[] gebruikerA = { 5, 1, 4, 2 };   // gaf Film 5 een 5
            double[] gebruikerC = { 4, 2, 5, 3 };   // gaf Film 5 een 2
            double cosA = rooster.Cosine(gebruikerX, gebruikerA);
            double cosC = rooster.Cosine(gebruikerX, gebruikerC);
            Console.WriteLine("Cosine X-A: " + Math.Round(cosA, 3) + "   (verwacht 0.963)");
            Console.WriteLine("Cosine X-C: " + Math.Round(cosC, 3) + "   (verwacht 1)");

            // TODO: k = 1 -> neem de rating van de gebruiker met de HOOGSTE cosine (verwacht 2)
            // TODO: k = 2 -> neem het gemiddelde van beide ratings          (verwacht 3.5)

            // ===== BONUS =====
            // B1  Gebruik Manhattan i.p.v. Distance in Classify. Verandert de voorspelling in blok 3?
            // B2  Probeer k = 2 op het rooster. Wat geeft jouw Classify bij een gelijkspel?
            // B3  Classificeer na normalisatie (k = 3) drie nieuwe klanten:
            //     60 jaar / 650 min,  20 jaar / 150 min,  35 jaar / 400 min
            //     Klopt het met je gevoel? Bij welke klant twijfelen de buren?
            // B4  Schrijf NormalizeZScore: (waarde - gemiddelde) / standaardafwijking. Zelfde voorspelling?
            // B5  Echte data: KNN iris = new KNN("iris.dat");
            //     iris.Classify(new double[] { 6.1, 2.8, 4.9, 1.7 }, 5)  -> welke soort iris?
        }
    }
}
