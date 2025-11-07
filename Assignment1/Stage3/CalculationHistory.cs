using System;

namespace Stage3;

/// <summary>
/// Verwaltung der Berechnungshistorie
/// Stage 3: Speichert die letzten 5 Berechnungen
/// </summary>
public static class CalculationHistory
{
    // Historie-Variablen (ohne Arrays, wie in der Angabenstellung)
    private static string _history1 = "";
    private static string _history2 = "";
    private static string _history3 = "";
    private static string _history4 = "";
    private static string _history5 = "";

    /// <summary>
    /// Fügt eine neue Berechnung zur Historie hinzu
    /// </summary>
    /// <param name="calculation">Die Berechnung als formatierter String</param>
    public static void AddToHistory(string calculation)
    {
        // Shift history
        _history5 = _history4;
        _history4 = _history3;
        _history3 = _history2;
        _history2 = _history1;
        _history1 = calculation;
    }

    /// <summary>
    /// Zeigt die Berechnungshistorie an
    /// </summary>
    public static void ShowHistory()
    {
        Console.WriteLine("\n╔══════════════════════════════════════════════╗");
        Console.WriteLine("║           BERECHNUNGSHISTORIE                ║");
        Console.WriteLine("╠══════════════════════════════════════════════╣");

        if (string.IsNullOrEmpty(_history1))
        {
            Console.WriteLine("║  Noch keine Berechnungen vorhanden           ║");
        }
        else
        {
            if (!string.IsNullOrEmpty(_history1))
            {
                Console.WriteLine($"║  1. {_history1,-40} ║");
            }

            if (!string.IsNullOrEmpty(_history2))
            {
                Console.WriteLine($"║  2. {_history2,-40} ║");
            }

            if (!string.IsNullOrEmpty(_history3))
            {
                Console.WriteLine($"║  3. {_history3,-40} ║");
            }

            if (!string.IsNullOrEmpty(_history4))
            {
                Console.WriteLine($"║  4. {_history4,-40} ║");
            }

            if (!string.IsNullOrEmpty(_history5))
            {
                Console.WriteLine($"║  5. {_history5,-40} ║");
            }
        }

        Console.WriteLine("╚══════════════════════════════════════════════╝");
        Console.WriteLine("\nDrücken Sie eine beliebige Taste zum Fortfahren...");
        Console.ReadKey();
    }

    // So würde mit Arrays aussehen:

    // public static class CalculationHistory
    // {
    //     private static List<string> _history = new List<string>();
    //     private const int MaxHistorySize = 5;
    //
    //     public static void AddToHistory(string calculation)
    //     {
    //         _history.Insert(0, calculation);
    //     
    //         if (_history.Count > MaxHistorySize)
    //         {
    //             _history.RemoveAt(MaxHistorySize);
    //         }
    //     }
    //
    //     public static void ShowHistory()
    //     {
    //         for (int i = 0; i < _history.Count; i++)
    //         {
    //             Console.WriteLine($"║  {i + 1}. {_history[i],-40} ║");
    //         }
    //     }
    // }
}