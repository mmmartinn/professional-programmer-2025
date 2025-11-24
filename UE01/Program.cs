using System.Globalization;

namespace UE01;

class Program
{
    public static void Main()
    {
        Console.WriteLine("=== BMI-Rechner ===");
        Console.WriteLine("Dieses Programm berechnet Ihren Body-Mass-Index (BMI).\n");

        try
        {
            double gewichtInKg = EingabeGewicht();

            double groesseInCm = EingabeGroesse();

            double bmi = BerechneBmi(gewichtInKg, groesseInCm);

            ZeigeErgebnis(bmi, gewichtInKg, groesseInCm);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nFehler: {ex.Message}");
            Console.WriteLine("Das Programm wird beendet.");
        }

        Console.WriteLine("\nDrücken Sie eine beliebige Taste zum Beenden...");
        Console.ReadKey();
    }

    private static double EingabeGewicht()
    {
        while (true)
        {
            Console.Write("Bitte geben Sie Ihr Körpergewicht in kg ein: ");
            string? eingabe = Console.ReadLine();

            if (eingabe == null)
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine Zahl ein (z.B. 75,5).");
                continue;
            }

            if (double.TryParse(eingabe, NumberStyles.Float, CultureInfo.CurrentCulture, out double gewicht))
            {
                if (gewicht > 0 && gewicht < 500) // Sinnvolle Grenzen
                {
                    return gewicht;
                }

                Console.WriteLine("Bitte geben Sie ein realistisches Gewicht zwischen 0 und 500 kg ein.");
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine Zahl ein (z.B. 75,5).");
            }
        }
    }

    private static double EingabeGroesse()
    {
        while (true)
        {
            Console.Write("Bitte geben Sie Ihre Körpergröße in cm ein: ");
            string? eingabe = Console.ReadLine();

            if (eingabe == null)
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine Zahl ein (z.B. 175).");
                continue;
            }

            if (double.TryParse(eingabe, NumberStyles.Float, CultureInfo.CurrentCulture, out double groesse))
            {
                if (groesse > 50 && groesse < 300) // Sinnvolle Grenzen
                {
                    return groesse;
                }

                Console.WriteLine("Bitte geben Sie eine realistische Größe zwischen 50 und 300 cm ein.");
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine Zahl ein (z.B. 175).");
            }
        }
    }

    private static double BerechneBmi(double gewichtInKg, double groesseInCm)
    {
        double groesseInM = groesseInCm / 100.0;
        return gewichtInKg / Math.Pow(groesseInM, 2);
    }

    private static void ZeigeErgebnis(double bmi, double gewicht, double groesse)
    {
        Console.WriteLine("\n=== Ergebnis ===");
        Console.WriteLine($"Gewicht: {gewicht:F1} kg");
        Console.WriteLine($"Größe: {groesse:F0} cm");
        Console.WriteLine($"BMI: {bmi:F1}");

        // BMI-Klassifikation nach WHO
        string klassifikation = GetBmiKlassifikation(bmi);
        Console.WriteLine($"Klassifikation: {klassifikation}");

        // Gesundheitshinweis
        Console.WriteLine("\nHinweis: Der BMI ist nur ein grober Richtwert und berücksichtigt nicht");
        Console.WriteLine("die individuelle Körperzusammensetzung (Muskelmasse, Knochenbau etc.).");
        Console.WriteLine("Für eine genaue Beurteilung konsultieren Sie bitte einen Arzt.");
    }

    private static string GetBmiKlassifikation(double bmi)
    {
        switch (bmi)
        {
            case var n when n < 16.0:
                return "Starkes Untergewicht";
            case var n when n < 17.0:
                return "Mäßiges Untergewicht";
            case var n when n < 18.5:
                return "Leichtes Untergewicht";
            case var n when n < 25.0:
                return "Normalgewicht";
            case var n when n < 30.0:
                return "Präadipositas (Übergewicht)";
            case var n when n < 35.0:
                return "Adipositas Grad I";
            case var n when n < 40.0:
                return "Adipositas Grad II";
            default:
                return "Adipositas Grad III";
        }
    }
}