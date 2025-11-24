using System;

namespace Stage1;

/// <summary>
/// Calculator-Klasse mit Berechnungsmethoden
/// Assignment 2, Stage 1: Extract the Calculator Logic
/// </summary>
public class Calculator
{
    /// <summary>
    /// Addiert zwei Zahlen
    /// </summary>
    /// <param name="a">Erste Zahl</param>
    /// <param name="b">Zweite Zahl</param>
    /// <returns>Die Summe von a und b</returns>
    public double Add(double a, double b)
    {
        return a + b;
    }

    /// <summary>
    /// Subtrahiert zwei Zahlen
    /// </summary>
    /// <param name="a">Erste Zahl (Minuend)</param>
    /// <param name="b">Zweite Zahl (Subtrahend)</param>
    /// <returns>Die Differenz von a und b</returns>
    public double Subtract(double a, double b)
    {
        return a - b;
    }

    /// <summary>
    /// Multipliziert zwei Zahlen
    /// </summary>
    /// <param name="a">Erste Zahl</param>
    /// <param name="b">Zweite Zahl</param>
    /// <returns>Das Produkt von a und b</returns>
    public double Multiply(double a, double b)
    {
        return a * b;
    }

    /// <summary>
    /// Dividiert zwei Zahlen
    /// </summary>
    /// <param name="a">Dividend</param>
    /// <param name="b">Divisor</param>
    /// <returns>Der Quotient von a und b</returns>
    /// <exception cref="ArgumentException">Wird geworfen, wenn b gleich 0 ist</exception>
    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Division durch Null ist nicht erlaubt!");
        }

        return a / b;
    }

    /// <summary>
    /// Berechnet die Quadratwurzel einer Zahl
    /// </summary>
    /// <param name="a">Die Zahl, von der die Wurzel gezogen werden soll</param>
    /// <returns>Die Quadratwurzel von a</returns>
    /// <exception cref="ArgumentException">Wird geworfen, wenn a negativ ist</exception>
    public double SquareRoot(double a)
    {
        if (a < 0)
        {
            throw new ArgumentException("Quadratwurzel negativer Zahlen nicht möglich!");
        }

        return Math.Sqrt(a);
    }

    /// <summary>
    /// Berechnet die Potenz (baseNum^exponent)
    /// </summary>
    /// <param name="baseNum">Die Basis</param>
    /// <param name="exponent">Der Exponent</param>
    /// <returns>Das Ergebnis von baseNum^exponent</returns>
    public double Power(double baseNum, double exponent)
    {
        return Math.Pow(baseNum, exponent);
    }
}
