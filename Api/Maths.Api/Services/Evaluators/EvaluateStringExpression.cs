using System.Text;
using Maths.Api.Enums;
using Maths.Api.Exceptions;
using Maths.Api.Services.Expressions;
using Maths.Api.Services.Tokens;

namespace Maths.Api.Services.Evaluators;

/// <summary>
/// Convert string to infix expression
/// </summary>
public class EvaluateStringExpression : IEvaluator
{
    /// <summary>
    /// Evaluate string expression to infix expression with tokens
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    /// <exception cref="EvaluationException"></exception>
    public Expression Evaluate(Expression expression)
    {
        if (expression != null 
            && expression.Tokens.Count != 1
            && expression.Type != ExpressionType.InfixString)
        {
            throw new EvaluationException("Failed to evaluate expression: " +
                                          "The expression is not a string expression");
        }

        var stringExpression = expression?.ToString();
        
        if (string.IsNullOrWhiteSpace(stringExpression))
        {
            throw new EvaluationException(
                "Failed to evaluate expression: the input is empty");
        }

        if (stringExpression.Length < 3)
        {
            throw new EvaluationException(
                "Failed to evaluate expression: the input should be at least 3 characters long");
        }
        
        if(IsOperator(stringExpression.First()) 
           || IsOperator(stringExpression.Last() ) )
        {
            throw new EvaluationException(
                "Failed to evaluate expression: " +
                "the input should not begin or end with an operator: +-*/");
        }

        var tokens = new List<IToken>();
        var numbersBuffer = new StringBuilder();

        foreach (var c in stringExpression.Where(c => !char.IsWhiteSpace(c)))
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
                    throw new EvaluationException(
                        "Failed to evaluate expression: " +
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