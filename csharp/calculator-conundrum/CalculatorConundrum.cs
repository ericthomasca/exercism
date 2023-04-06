using System;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation)
    {
        if (operand2 == 0)
        {
            return "Division by zero is not allowed.";
        }
        else
        {
            int solutionValue;
            switch (operation)
            {
                case "+":
                    solutionValue = SimpleOperation.Addition(operand1, operand2);
                    break;
                case "*":
                    solutionValue = SimpleOperation.Multiplication(operand1, operand2);
                    break;
                case "/":
                    solutionValue = SimpleOperation.Division(operand1, operand2);
                    break;
                case "":
                    throw new ArgumentException();
                case null:
                    throw new ArgumentNullException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        
        return $"{operand1} {operation} {operand2} = {solutionValue}";
        }
    }
}
