using System.Text;
using Maths.Api.DataAccess;
using Maths.Api.Exceptions;
using Maths.Api.Services.Expressions;
using Maths.Api.Services.Tokens;

namespace Maths.Api.Services.Converters;

/// <summary>
/// Convert string to infix expression
/// </summary>
public class StringToInfixExpressionConverter : IStringToInfixExpressionConverter
{
    /// <summary>
    /// Convert string to infix expression
    /// </summary>
    /// <param name="inputExpressionDto"></param>
    /// <returns></returns>
    public InfixExpression ConvertToInfixExpression(InputExpressionDto inputExpressionDto)
    {
        var input = inputExpressionDto.Expression;

        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ConvertToInfixExpressionException("Expression should not be empty");
        }

        if (input.Length < 3)
        {
            throw new ConvertToInfixExpressionException(
                "Expression should at least be 3 characters long");
        }
        
        if(IsOperator(input.First()) || IsOperator(input.Last() ) )
        {
            throw new ConvertToInfixExpressionException(
                "Expression should not begin or end with an operator: +-*/");
        }

        var tokens = new List<IToken>();
        var numbersBuffer = new StringBuilder();

        foreach (var c in input.Where(c => !char.IsWhiteSpace(c)))
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
                    throw new ConvertToInfixExpressionException(
                        "Expression should contain only numbers and +-*/");
                }
            }
            else
            {
                numbersBuffer.Append(c);
            }
        }

        var remainingNumbers = numbersBuffer.ToString();
        tokens.Add(new NumberToken(remainingNumbers));

        return new InfixExpression(tokens);
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