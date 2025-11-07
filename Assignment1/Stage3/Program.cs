using System;
using System.Globalization;
using System.Text;

namespace Stage3;

/// <summary>
/// Multi-Stage Calculator - Stage 3: Scientific Calculator
/// Entwickelt für: Research Division
/// Hauptprogramm - Orchestriert die Calculator-Funktionalität mit Menüsystem
/// </summary>
class Program
{
    static void Main()
    {
        // Setze die Konsolen-Codierung auf UTF-8 für korrekte Darstellung von Sonderzeichen
        Console.OutputEncoding = Encoding.UTF8;

        CalculatorHelper.ShowWelcomeScreen();

        bool continueProgram = true;

        while (continueProgram)
        {
            // Zeige Hauptmenü und hole Benutzerwahl
            int choice = CalculatorHelper.ShowMainMenu();

            switch (choice)
            {
                case 1:
                    // Grundrechenarten
                    PerformBasicCalculation();
                    break;

                case 2:
                    // Quadratwurzel
                    PerformSquareRoot();
                    break;

                case 3:
                    // Potenz
                    PerformPower();
                    break;

                case 4:
                    // Historie anzeigen
                    CalculationHistory.ShowHistory();
                    break;

                case 5:
                    // Beenden
                    continueProgram = false;
                    break;
            }
        }

        CalculatorHelper.ShowGoodbyeMessage();
    }

    /// <summary>
    /// Führt eine Grundrechenart aus
    /// </summary>
    private static void PerformBasicCalculation()
    {
        Console.Clear();
        Console.WriteLine("=== Grundrechenarten ===\n");

        try
        {
            double firstNumber = CalculatorHelper.ReadNumber("erste");
            double secondNumber = CalculatorHelper.ReadNumber("zweite");
            string operation = CalculatorHelper.ChooseOperation();

            Calculator.CalculateAndShowResult(firstNumber, secondNumber, operation);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nUnerwarteter Fehler: {ex.Message}");
        }

        Console.WriteLine("\nDrücken Sie eine beliebige Taste zum Fortfahren...");
        Console.ReadKey();
    }

    /// <summary>
    /// Führt eine Quadratwurzel-Berechnung aus
    /// </summary>
    private static void PerformSquareRoot()
    {
        Console.Clear();
        Console.WriteLine("=== Quadratwurzel ===\n");

        try
        {
            Console.Write("Bitte geben Sie eine Zahl ein: ");
            string? input = Console.ReadLine();

            if (input != null &&
                double.TryParse(input, NumberStyles.Float, CultureInfo.CurrentCulture, out double number))
            {
                Calculator.CalculateSquareRoot(number);
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nUnerwarteter Fehler: {ex.Message}");
        }

        Console.WriteLine("\nDrücken Sie eine beliebige Taste zum Fortfahren...");
        Console.ReadKey();
    }

    /// <summary>
    /// Führt eine Potenz-Berechnung aus
    /// </summary>
    private static void PerformPower()
    {
        Console.Clear();
        Console.WriteLine("=== Potenz (x^y) ===\n");

        try
        {
            Console.Write("Bitte geben Sie die Basis ein: ");
            string? baseInput = Console.ReadLine();

            if (baseInput != null && double.TryParse(baseInput, NumberStyles.Float, CultureInfo.CurrentCulture,
                    out double baseNumber))
            {
                Console.Write("Bitte geben Sie den Exponenten ein: ");
                string? expInput = Console.ReadLine();

                if (expInput != null && double.TryParse(expInput, NumberStyles.Float, CultureInfo.CurrentCulture,
                        out double exponent))
                {
                    Calculator.CalculatePower(baseNumber, exponent);
                }
                else
                {
                    Console.WriteLine("Ungültiger Exponent!");
                }
            }
            else
            {
                Console.WriteLine("Ungültige Basis!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nUnerwarteter Fehler: {ex.Message}");
        }

        Console.WriteLine("\nDrücken Sie eine beliebige Taste zum Fortfahren...");
        Console.ReadKey();
    }
}