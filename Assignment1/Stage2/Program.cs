using System;
using System.Text;

namespace Stage2;

/// <summary>
/// Multi-Stage Calculator - Stage 2: Enhanced Error Handling
/// Entwickelt für: Engineering Team
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
            CalculatorHelper.ShowWelcomeScreen();

            try
            {
                double firstNumber = CalculatorHelper.ReadNumber("erste");
                double secondNumber = CalculatorHelper.ReadNumber("zweite");

                string operation = CalculatorHelper.ChooseOperation();

                Calculator.CalculateAndShowResult(firstNumber, secondNumber, operation);

                // Frage nach weiterer Berechnung
                continueCalculation = CalculatorHelper.AskForAnotherCalculation();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nUnerwarteter Fehler: {ex.Message}");
                Console.WriteLine("Drücken Sie eine beliebige Taste zum Fortfahren...");
                Console.ReadKey();
            }
        }

        CalculatorHelper.ShowGoodbyeMessage();
    }
}