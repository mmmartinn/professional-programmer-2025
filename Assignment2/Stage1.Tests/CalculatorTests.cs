using Xunit;
using Stage1;

namespace Stage1.Tests;

/// <summary>
/// Unit Tests für die Calculator-Klasse
/// Assignment 2, Stage 2: Write Unit Tests
/// </summary>
public class CalculatorTests
{
    private readonly Calculator _calculator;

    public CalculatorTests()
    {
        _calculator = new Calculator();
    }

    [Fact]
    public void Add_TwoPositiveNumbers_ReturnsSum()
    {
        // Arrange
        double a = 5;
        double b = 3;

        // Act
        double result = _calculator.Add(a, b);

        // Assert
        Assert.Equal(8, result);
    }

    [Fact]
    public void Subtract_TwoPositiveNumbers_ReturnsDifference()
    {
        // Arrange
        double a = 10;
        double b = 4;

        // Act
        double result = _calculator.Subtract(a, b);

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void Multiply_TwoPositiveNumbers_ReturnsProduct()
    {
        // Arrange
        double a = 7;
        double b = 6;

        // Act
        double result = _calculator.Multiply(a, b);

        // Assert
        Assert.Equal(42, result);
    }

    [Fact]
    public void Divide_TwoPositiveNumbers_ReturnsQuotient()
    {
        // Arrange
        double a = 15;
        double b = 3;

        // Act
        double result = _calculator.Divide(a, b);

        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void SquareRoot_PositiveNumber_ReturnsSquareRoot()
    {
        // Arrange
        double a = 16;

        // Act
        double result = _calculator.SquareRoot(a);

        // Assert
        Assert.Equal(4, result);
    }

    [Fact]
    public void Power_TwoPositiveNumbers_ReturnsPower()
    {
        // Arrange
        double baseNum = 2;
        double exponent = 8;

        // Act
        double result = _calculator.Power(baseNum, exponent);

        // Assert
        Assert.Equal(256, result);
    }

    [Fact]
    public void Divide_ByZero_ThrowsArgumentException()
    {
        // Arrange
        double a = 10;
        double b = 0;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _calculator.Divide(a, b));
    }

    [Fact]
    public void SquareRoot_NegativeNumber_ThrowsArgumentException()
    {
        // Arrange
        double a = -4;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _calculator.SquareRoot(a));
    }
}

