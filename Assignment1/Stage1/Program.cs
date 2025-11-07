using System;
using System.Globalization;
using System.Text;

namespace Stage1;

/// <summary>
/// Multi-Stage Calculator - Stage 1: Basic Calculator
/// Entwickelt für: Accounting Department
/// </summary>
class Program
{
    static void Main()
    {
        // Setze die Konsolen-Codierung auf UTF-8 für korrekte Darstellung von Sonderzeichen
        Console.OutputEncoding = Encoding.UTF8;

        bool continueCalculation = true;

        while (continueCalculation)
        {
            Console.Clear();
            ShowWelcomeScreen();

            try
            {
                // Schritt 1: Erste Zahl eingeben
                double firstNumber = ReadNumber("erste");

                // Schritt 2: Zweite Zahl eingeben
                double secondNumber = ReadNumber("zweite");

                // Schritt 3: Operation auswählen
                string operation = ChooseOperation();

                // Schritt 4: Berechnung durchführen
                CalculateAndShowResult(firstNumber, secondNumber, operation);

                // Frage nach weiterer Berechnung
                continueCalculation = AskForAnotherCalculation();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nUnerwarteter Fehler: {ex.Message}");
                Console.WriteLine("Drücken Sie eine beliebige Taste zum Fortfahren...");
                Console.ReadKey();
            }
        }

        ShowGoodbyeMessage();
    }

    // ----- Hilfsmethoden -----

    private static void ShowWelcomeScreen()
    {
        // Quelle Box drawing characters:
        // https://en.wikipedia.org/wiki/Box-drawing_character
        // https://jrgraphix.net/r/Unicode/2500-257F?utm_source=chatgpt.com

        Console.WriteLine("╔══════════════════════════════════════════════╗");
        Console.WriteLine("║   TechStart Industries - Basic Calculator    ║");
        Console.WriteLine("║         Stage 1: Accounting Department       ║");
        Console.WriteLine("╚══════════════════════════════════════════════╝\n");
    }

    private static double ReadNumber(string position)
    {
        while (true)
        {
            Console.Write($"Bitte geben Sie die {position} Zahl ein: ");
            string? input = Console.ReadLine();

            if (input == null)
            {
                Console.WriteLine("Fehler: Keine Eingabe erkannt. Bitte versuchen Sie es erneut.");
                continue;
            }

            if (double.TryParse(input, NumberStyles.Float, CultureInfo.CurrentCulture, out double number))
            {
                return number;
            }

            Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige Zahl ein (z.B. 42 oder 3,14).");
        }
    }

    private static string ChooseOperation()
    {
        while (true)
        {
            Console.WriteLine("\n┌─────────────────────────────┐");
            Console.WriteLine("│  Verfügbare Operationen:    │");
            Console.WriteLine("├─────────────────────────────┤");
            Console.WriteLine("│  [+] Addition               │");
            Console.WriteLine("│  [-] Subtraktion            │");
            Console.WriteLine("│  [*] Multiplikation         │");
            Console.WriteLine("│  [/] Division               │");
            Console.WriteLine("└─────────────────────────────┘");

            Console.Write("\nBitte wählen Sie eine Operation (+, -, *, /): ");
            string? operation = Console.ReadLine();

            if (operation == null)
            {
                Console.WriteLine("Fehler: Keine Operation eingegeben!");
                continue;
            }

            // Trimmen für den Fall von versehentlichen Leerzeichen
            operation = operation.Trim();

            if (operation == "+" || operation == "-" || operation == "*" || operation == "/")
            {
                return operation;
            }

            Console.WriteLine($"\nFehler: '{operation}' ist keine gültige Operation!");
            Console.WriteLine("Bitte verwenden Sie nur +, -, * oder /");
        }
    }

    private static void CalculateAndShowResult(double number1, double number2, string operation)
    {
        double result;
        string calculation;
        string operationName;

        // Berechnung mit if/else statements (wie in den Anforderungen gefordert)
        if (operation == "+")
        {
            result = number1 + number2;
            operationName = "Addition";
            calculation = FormatCalculationString(number1, number2, result, operation);
        }
        else if (operation == "-")
        {
            result = number1 - number2;
            operationName = "Subtraktion";
            calculation = FormatCalculationString(number1, number2, result, operation);
        }
        else if (operation == "*")
        {
            result = number1 * number2;
            operationName = "Multiplikation";
            calculation = FormatCalculationString(number1, number2, result, operation);
        }
        else if (operation == "/")
        {
            // In Stage 1 führen wir die Division einfach durch
            // C# gibt bei Division durch 0 "Infinity" zurück
            result = number1 / number2;
            operationName = "Division";
            calculation = FormatCalculationString(number1, number2, result, operation);
        }
        else
        {
            Console.WriteLine("Unbekannte Operation!");
            return;
        }

        // Ergebnis anzeigen
        Console.WriteLine("\n╔══════════════════════════════════════════╗");
        Console.WriteLine("║              ERGEBNIS                    ║");
        Console.WriteLine("╠══════════════════════════════════════════╣");
        Console.WriteLine($"║  Operation: {operationName,-27}  ║");
        Console.WriteLine("╠══════════════════════════════════════════╣");
        Console.WriteLine($"║  {calculation,-38}  ║");
        Console.WriteLine("╚══════════════════════════════════════════╝");
    }

    private static string FormatCalculationString(double number1, double number2, double result, string operation)
    {
        // Formatierung mit passender Anzahl Dezimalstellen
        string num1 = FormatNumber(number1);
        string num2 = FormatNumber(number2);
        string res = FormatNumber(result);

        return $"{num1} {operation} {num2} = {res}";
    }

    private static string FormatNumber(double number)
    {
        // Spezielle Werte behandeln
        if (double.IsPositiveInfinity(number))
        {
            // Quelle Unendlich-Zeichen:
            // https://www.compart.com/de/unicode/U+221E
            return "+∞ (Unendlich)";
        }

        if (double.IsNegativeInfinity(number))
        {
            return "-∞ (Unendlich)";
        }

        if (double.IsNaN(number))
        {
            return "Undefiniert";
        }

        if (IsWholeNumber(number))
            return number.ToString("F0", CultureInfo.CurrentCulture);
        else
            return number.ToString("F2", CultureInfo.CurrentCulture);
    }

    /// <summary>
    /// Prüft, ob eine Gleitkommazahl als Ganzzahl betrachtet werden kann.
    /// Verwendet eine Epsilon-Vergleich.
    /// </summary>
    private static bool IsWholeNumber(double number)
    {
        const double epsilon = 1e-9; // 0.000000001
        return Math.Abs(number - Math.Round(number)) < epsilon;
    }

    private static bool AskForAnotherCalculation()
    {
        while (true)
        {
            Console.Write("\nMöchten Sie eine weitere Berechnung durchführen? (j/n): ");
            string? answer = Console.ReadLine();

            if (answer == null)
            {
                Console.WriteLine("Bitte geben Sie 'j' für Ja oder 'n' für Nein ein.");
                continue;
            }

            answer = answer.Trim().ToLower();

            if (answer == "j" || answer == "ja")
            {
                return true;
            }
            else if (answer == "n" || answer == "nein")
            {
                return false;
            }
            else
            {
                Console.WriteLine(
                    $"'{answer}' ist keine gültige Eingabe. Bitte geben Sie 'j' für Ja oder 'n' für Nein ein.");
            }
        }
    }

    private static void ShowGoodbyeMessage()
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════════════════════╗");
        Console.WriteLine("║                                              ║");
        Console.WriteLine("║       Vielen Dank für die Nutzung des        ║");
        Console.WriteLine("║      TechStart Industries Calculators!       ║");
        Console.WriteLine("║                                              ║");
        Console.WriteLine("║             Das Accounting Team              ║");
        Console.WriteLine("║                                              ║");
        Console.WriteLine("╚══════════════════════════════════════════════╝");
        Console.WriteLine("\nDrücken Sie eine beliebige Taste zum Beenden...");
        Console.ReadKey();
    }
}