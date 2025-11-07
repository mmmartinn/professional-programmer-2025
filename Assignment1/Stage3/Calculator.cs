using System;

namespace Stage3;

/// <summary>
/// Calculator-Klasse mit der Hauptberechnungslogik
/// Stage 3: Mit switch/case, Modulo und wissenschaftlichen Funktionen
/// </summary>
public static class Calculator
{
    /// <summary>
    /// Führt die Berechnung durch und zeigt das Ergebnis an
    /// </summary>
    /// <param name="number1">Erste Zahl</param>
    /// <param name="number2">Zweite Zahl</param>
    /// <param name="operation">Gewählte Operation</param>
    public static void CalculateAndShowResult(double number1, double number2, string operation)
    {
        double result;
        string calculation;
        string operationName;

        // Stage 2: Verwende switch/case statt if/else (Engineering Team Anforderung)
        operation = operation.Trim();
        switch (operation)
        {
            case "+":
                result = number1 + number2;
                operationName = "Addition";
                calculation = CalculatorHelper.FormatCalculationString(number1, number2, result, operation);
                break;

            case "-":
                result = number1 - number2;
                operationName = "Subtraktion";
                calculation = CalculatorHelper.FormatCalculationString(number1, number2, result, operation);
                break;

            case "*":
                result = number1 * number2;
                operationName = "Multiplikation";
                calculation = CalculatorHelper.FormatCalculationString(number1, number2, result, operation);
                break;

            case "/":
                // Stage 2: Division durch Null-Behandlung
                if (number2 == 0)
                {
                    CalculatorHelper.ShowError(
                        "Division durch Null ist nicht erlaubt!",
                        "Das kann zu Systemabstürzen führen!"
                    );
                    return;
                }

                result = number1 / number2;
                operationName = "Division";
                calculation = CalculatorHelper.FormatCalculationString(number1, number2, result, operation);
                break;

            case "%":
                // Stage 2: Modulo-Operation für Engineering Team
                if (number2 == 0)
                {
                    CalculatorHelper.ShowError(
                        "Modulo durch Null ist nicht erlaubt!",
                        "Das kann zu Systemabstürzen führen!"
                    );
                    return;
                }

                result = number1 % number2;
                operationName = "Modulo (Rest)";
                calculation = CalculatorHelper.FormatCalculationString(number1, number2, result, operation);
                break;

            default:
                CalculatorHelper.ShowError("Unbekannte Operation!", "");
                return;
        }

        CalculatorHelper.ShowResult(operationName, calculation);

        CalculationHistory.AddToHistory(calculation);
    }

    /// <summary>
    /// Führt eine Quadratwurzel-Berechnung durch
    /// </summary>
    /// <param name="number">Die Zahl, von der die Wurzel gezogen werden soll</param>
    public static void CalculateSquareRoot(double number)
    {
        // Validierung: Negative Zahlen sind nicht erlaubt
        if (number < 0)
        {
            CalculatorHelper.ShowError(
                "Quadratwurzel negativer Zahlen nicht möglich!",
                "Nur positive Zahlen oder 0 sind erlaubt."
            );
            return;
        }

        double result = Math.Sqrt(number);
        string calculation = $"√{CalculatorHelper.FormatNumber(number)} = {CalculatorHelper.FormatNumber(result)}";

        CalculatorHelper.ShowResult("Quadratwurzel", calculation);

        CalculationHistory.AddToHistory(calculation);
    }

    /// <summary>
    /// Führt eine Potenz-Berechnung durch (base^exponent)
    /// </summary>
    /// <param name="baseNumber">Die Basis</param>
    /// <param name="exponent">Der Exponent</param>
    public static void CalculatePower(double baseNumber, double exponent)
    {
        double result = Math.Pow(baseNumber, exponent);
        string calculation =
            $"{CalculatorHelper.FormatNumber(baseNumber)}^{CalculatorHelper.FormatNumber(exponent)} = {CalculatorHelper.FormatNumber(result)}";

        // Ergebnis anzeigen
        CalculatorHelper.ShowResult("Potenz", calculation);

        // Zur Historie hinzufügen
        CalculationHistory.AddToHistory(calculation);
    }
}