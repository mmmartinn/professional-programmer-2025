using System;
using System.Globalization;

namespace Stage2;

/// <summary>
/// Helper-Klasse für Calculator-Funktionen
/// Enthält alle wiederverwendbaren Methoden für Input/Output und Formatierung
/// </summary>
public static class CalculatorHelper
{
    /// <summary>
    /// Zeigt den Willkommensbildschirm an
    /// </summary>
    public static void ShowWelcomeScreen()
    {
        Console.WriteLine("╔══════════════════════════════════════════════╗");
        Console.WriteLine("║   TechStart Industries Calculator v2.0       ║");
        Console.WriteLine("║   Stage 2: Enhanced for Engineering Team     ║");
        Console.WriteLine("╚══════════════════════════════════════════════╝\n");
    }

    /// <summary>
    /// Liest eine Zahl vom Benutzer ein mit Validierung
    /// </summary>
    /// <param name="position">Beschreibung der Zahl (erste/zweite)</param>
    /// <returns>Die eingegebene Zahl</returns>
    public static double ReadNumber(string position)
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

            Console.WriteLine($"Ungültige Eingabe. Bitte geben Sie eine gültige Zahl ein (z.B. 42 oder 3,14).");
        }
    }

    /// <summary>
    /// Lässt den Benutzer eine Operation auswählen
    /// </summary>
    /// <returns>Das gewählte Operations-Symbol</returns>
    public static string ChooseOperation()
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
            Console.WriteLine("│  [%] Modulo (Rest)          │");
            Console.WriteLine("└─────────────────────────────┘");

            Console.Write("\nBitte wählen Sie eine Operation (+, -, *, /, %): ");
            string? operation = Console.ReadLine();

            if (operation == null)
            {
                Console.WriteLine("Fehler: Keine Operation eingegeben!");
                continue;
            }

            operation = operation.Trim();

            if (operation == "+" ||
                operation == "-" ||
                operation == "*" ||
                operation == "/" ||
                operation == "%")
            {
                return operation;
            }

            Console.WriteLine($"\nFehler: '{operation}' ist keine gültige Operation!");
            Console.WriteLine("Bitte verwenden Sie nur +, -, *, / oder %");

            // switch (operation)
            // {
            //     case "+":
            //     case "-":
            //     case "*":
            //     case "/":
            //     case "%":
            //         return operation;
            //     default:
            //         Console.WriteLine($"\nFehler: '{operation}' ist keine gültige Operation!");
            //         Console.WriteLine("Bitte verwenden Sie nur +, -, *, / oder %");
            //         break;
            // }
        }
    }

    /// <summary>
    /// Zeigt eine Fehlermeldung in einer formatierten Box an
    /// </summary>
    /// <param name="title">Titel der Fehlermeldung</param>
    /// <param name="message">Fehlernachricht</param>
    public static void ShowError(string title, string message)
    {
        Console.WriteLine("\n╔══════════════════════════════════════════╗");
        Console.WriteLine("║              FEHLER                      ║");
        Console.WriteLine("╠══════════════════════════════════════════╣");
        Console.WriteLine($"║  {title,-38}  ║");
        if (!string.IsNullOrEmpty(message))
        {
            Console.WriteLine($"║  {message,-38}  ║");
        }

        Console.WriteLine("╚══════════════════════════════════════════╝");
    }

    /// <summary>
    /// Zeigt das Berechnungsergebnis in einer formatierten Box an
    /// </summary>
    /// <param name="operationName">Name der Operation</param>
    /// <param name="calculation">Formatierte Berechnung</param>
    public static void ShowResult(string operationName, string calculation)
    {
        Console.WriteLine("\n╔══════════════════════════════════════════╗");
        Console.WriteLine("║              ERGEBNIS                    ║");
        Console.WriteLine("╠══════════════════════════════════════════╣");
        Console.WriteLine($"║  Operation: {operationName,-27}  ║");
        Console.WriteLine("╠══════════════════════════════════════════╣");
        Console.WriteLine($"║  {calculation,-38}  ║");
        Console.WriteLine("╚══════════════════════════════════════════╝");
    }

    /// <summary>
    /// Formatiert eine Berechnung als String
    /// </summary>
    public static string FormatCalculationString(double number1, double number2, double result, string operation)
    {
        string num1 = FormatNumber(number1);
        string num2 = FormatNumber(number2);
        string res = FormatNumber(result);

        return $"{num1} {operation} {num2} = {res}";
    }

    /// <summary>
    /// Formatiert eine Zahl für die Anzeige
    /// </summary>
    public static string FormatNumber(double number)
    {
        // Spezielle Werte behandeln
        if (double.IsPositiveInfinity(number))
        {
            // Alternative: return "+INF (Unendlich)";
            return "+∞ (Unendlich)";
        }

        if (double.IsNegativeInfinity(number))
        {
            // Alternative: return "-INF (Unendlich)";
            return "-∞ (Unendlich)";
        }

        if (double.IsNaN(number))
        {
            return "Undefiniert";
        }

        // Best Practice: Epsilon-Vergleich für Floating-Point-Zahlen
        // Dies ist der Industriestandard für sichere Gleitkomma-Vergleiche
        if (IsWholeNumber(number))
            return number.ToString("F0", CultureInfo.CurrentCulture);
        else
            return number.ToString("F2", CultureInfo.CurrentCulture);
    }

    /// <summary>
    /// Checks whether a floating-point number can be considered an integer.
    /// Uses an epsilon comparison.
    /// </summary>
    public static bool IsWholeNumber(double number)
    {
        const double epsilon = 1e-9; // 0.000000001
        return Math.Abs(number - Math.Round(number)) < epsilon;
    }

    /// <summary>
    /// Fragt den Benutzer, ob eine weitere Berechnung durchgeführt werden soll
    /// </summary>
    /// <returns>true wenn ja, false wenn nein</returns>
    public static bool AskForAnotherCalculation()
    {
        while (true)
        {
            Console.Write("\nMöchten Sie eine weitere Berechnung durchführen? (y/n): ");
            string? answer = Console.ReadLine();

            if (answer == null)
            {
                Console.WriteLine("Bitte geben Sie 'y' für Ja oder 'n' für Nein ein.");
                continue;
            }

            // Stage 2: Verwende ToLower() für case-insensitive Vergleich
            answer = answer.Trim().ToLower();

            if (answer == "y" || answer == "yes")
            {
                return true;
            }
            else if (answer == "n" || answer == "no")
            {
                return false;
            }
            else
            {
                Console.WriteLine(
                    $"'{answer}' ist keine gültige Eingabe. Bitte geben Sie 'y' für Ja oder 'n' für Nein ein.");
            }
        }
    }

    /// <summary>
    /// Zeigt die Abschiedsnachricht an
    /// </summary>
    public static void ShowGoodbyeMessage()
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════════════════════╗");
        Console.WriteLine("║                                              ║");
        Console.WriteLine("║       Vielen Dank für die Nutzung des        ║");
        Console.WriteLine("║      TechStart Industries Calculators!       ║");
        Console.WriteLine("║                                              ║");
        Console.WriteLine("║            Das Engineering Team              ║");
        Console.WriteLine("║                                              ║");
        Console.WriteLine("╚══════════════════════════════════════════════╝");
        Console.WriteLine("\nDrücken Sie eine beliebige Taste zum Beenden...");
        Console.ReadKey();
    }
}