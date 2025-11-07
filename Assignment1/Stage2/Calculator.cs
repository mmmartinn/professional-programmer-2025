namespace Stage2;

/// <summary>
/// Calculator-Klasse mit der Hauptberechnungslogik
/// Stage 2: Mit switch/case und Modulo-Operation
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
    }
}