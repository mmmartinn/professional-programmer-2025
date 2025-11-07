using System;
using System.Globalization;

namespace Stage3;

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
        Console.WriteLine("║   TechStart Industries Calculator v3.0       ║");
        Console.WriteLine("║   Stage 3: Scientific for Research Division  ║");
        Console.WriteLine("╚══════════════════════════════════════════════╝\n");
    }

    /// <summary>
    /// Zeigt das Hauptmenü an und lässt den Benutzer eine Option wählen
    /// </summary>
    /// <returns>Die gewählte Menüoption (1-5)</returns>
    public static int ShowMainMenu()
    {
        while (true)
        {
            Console.WriteLine("\n╔══════════════════════════════════════════════╗");
            Console.WriteLine("║              HAUPTMENÜ                       ║");
            Console.WriteLine("╠══════════════════════════════════════════════╣");
            Console.WriteLine("║  1. Grundrechenarten (+, -, *, /, %)         ║");
            Console.WriteLine("║  2. Quadratwurzel (√)                        ║");
            Console.WriteLine("║  3. Potenz (x^y)                             ║");
            Console.WriteLine("║  4. Berechnungshistorie anzeigen             ║");
            Console.WriteLine("║  5. Beenden                                  ║");
            Console.WriteLine("╚══════════════════════════════════════════════╝");

            Console.Write("\nBitte wählen Sie eine Option (1-5): ");
            string? input = Console.ReadLine();

            if (input == null)
            {
                Console.WriteLine("Ungültige Eingabe. Bitte wählen Sie 1-5.");
                continue;
            }

            if (int.TryParse(input.Trim(), out int choice) && choice >= 1 && choice <= 5)
            {
                return choice;
            }

            Console.WriteLine("Ungültige Eingabe. Bitte wählen Sie eine Zahl zwischen 1 und 5.");
        }
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

            // Mit "switch-case":
            
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

        // Epsilon-Vergleich für Floating-Point-Zahlen
        if (IsWholeNumber(number))
        {
            return number.ToString("F0", CultureInfo.CurrentCulture);
        }
        else
            return number.ToString("F2", CultureInfo.CurrentCulture);
    }

    /// <summary>
    /// Prüft, ob eine Gleitkommazahl als Ganzzahl betrachtet werden kann.
    /// Verwendet eine Epsilon-Vergleich.
    /// </summary>
    public static bool IsWholeNumber(double number)
    {
        const double epsilon = 1e-9; // 0.000000001
        return Math.Abs(number - Math.Round(number)) < epsilon;
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
        Console.WriteLine("║           Die Research Division              ║");
        Console.WriteLine("║                                              ║");
        Console.WriteLine("╚══════════════════════════════════════════════╝");
        Console.WriteLine("\nDrücken Sie eine beliebige Taste zum Beenden...");
        Console.ReadKey();
    }
}