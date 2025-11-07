# Multi-Stage Calculator

A console-based scientific calculator built with C# and .NET 8.0, developed for TechStart Industries.

## Overview

This project demonstrates the iterative development of a calculator application across four stages, each adding new features based on different department requirements at TechStart Industries.

## Project Structure

```
Assignment1/
├── Stage1/    # Basic Calculator (Accounting Department)
├── Stage2/    # Enhanced Calculator with Error Handling (Engineering Team)
├── Stage3/    # Scientific Calculator with Menu System (Research Division)
└── Stage4/    # Professional Polish and Documentation (Management)
```

## Features by Stage

### Stage 1: Basic Calculator
- Basic arithmetic operations (+, -, *, /, %)
- Input validation
- Multiple calculations without restart

### Stage 2: Enhanced Calculator
- Switch/case operation selection
- Modulo operation (%)
- Division by zero validation
- Code refactored into separate classes

### Stage 3: Scientific Calculator
- Menu-based navigation system
- Square root operation with validation
- Power operation (x^y)
- Calculation history (last 5 calculations)
- CultureInfo support for international number formats

### Stage 4: Professional Polish (not included)
- This stage is not implemented separately, as all polishing steps (documentation, error handling, and clean code practices) were already integrated progressively throughout Stages 1–3.

## How to Run

1. Clone this repository
2. Navigate to the desired stage directory:
   ```
   cd Assignment1/Stage3
   ```
3. Build and run the project:
   ```
   dotnet build
   dotnet run
   ```
4. OR open the solution in JetBrains Rider and press F5

## Example Usage

### Basic Operations (All Stages)
```
Enter first number: 10
Enter second number: 5
Enter operation (+, -, *, /, %): +
Result: 10 + 5 = 15
```

### Scientific Operations (Stage 3)
```
MAIN MENU
1. Basic operations (+, -, *, /, %)
2. Square root
3. Power (x^y)
4. View calculation history
5. Exit

Choice: 2
Enter number: 16
Result: √16 = 4
```

### Calculation History (Stage 3)
```
CALCULATION HISTORY
1. √16 = 4
2. 2^8 = 256
3. 10 + 5 = 15
```

## Technical Details

- **Language**: C# 
- **Framework**: .NET 9.0
- **IDE**: JetBrains Rider / Visual Studio
- **Key Concepts**: Object-Oriented Programming, Error Handling, Input Validation

## Learning Objectives

1. **Stage 1**: Basic programming concepts, if/else statements
2. **Stage 2**: Switch/case statements, error handling, code organization
3. **Stage 3**: Menu systems, advanced operations, data persistence
4. **Stage 4**: Professional documentation, code polish, best practices

## Author

Martin Naydenov

Date: November 3, 2025

Assignment 1: Multi-Stage Calculator Development