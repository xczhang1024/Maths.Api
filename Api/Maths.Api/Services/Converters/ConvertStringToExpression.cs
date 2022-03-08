using System.Text;
using Maths.Api.Enums;
using Maths.Api.Exceptions;
using Maths.Api.Services.Expressions;
using Maths.Api.Services.Tokens;

namespace Maths.Api.Services.Converters;

/// <summary>
/// Convert string to infix expression
/// </summary>
public class ConvertStringToExpression : IConvertFromString
{
    /// <summary>
    /// Convert string to infix expression
    /// </summary>
    /// <param name="expressionString"></param>
    /// <returns></returns>
    public Expression Convert(string expressionString)
    {
        if (string.IsNullOrWhiteSpace(expressionString))
        {
            throw new ConversionException(
                "Failed to convert expression: the input is empty");
        }

        if (expressionString.Length < 3)
        {
            throw new ConversionException(
                "Failed to convert expression: the input should be at least 3 characters long");
        }
        
        if(IsOperator(expressionString.First()) 
           || IsOperator(expressionString.Last() ) )
        {
            throw new ConversionException(
                "Failed to convert expression: " +
                "the input should not begin or end with an operator: +-*/");
        }

        var tokens = new List<IToken>();
        var numbersBuffer = new StringBuilder();

        foreach (var c in expressionString.Where(c => !char.IsWhiteSpace(c)))
        {
            if (IsOperator(c))
            {
                // Get all out of numbers buffer and try to parse as double
                var possibleNumber = numbersBuffer.ToString();
                
                if (double.TryParse(possibleNumber, out var value))
                {
                    tokens.Add(new NumberToken(value));
                    tokens.Add(new OperatorToken(c));
                    numbersBuffer.Clear();
                }
                else
                {
                    throw new ConversionException(
                        "Failed to convert expression: " +
                        "the input should contain only positive numbers and +-*/ characters");
                }
            }
            else
            {
                numbersBuffer.Append(c);
            }
        }

        var remainingNumbers = numbersBuffer.ToString();
        tokens.Add(new NumberToken(remainingNumbers));

        return new Expression(tokens, ExpressionType.Infix);
    }

    /// <summary>
    /// Returns true if the char is an operator
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    private static bool IsOperator(char c)
    {
        const string operators = "+-/*";
        return operators.Contains(c);
    }
}