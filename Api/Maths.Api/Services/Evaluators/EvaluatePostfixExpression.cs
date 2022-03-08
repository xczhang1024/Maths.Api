using System.Data;
using Maths.Api.Enums;
using Maths.Api.Exceptions;
using Maths.Api.Services.Expressions;
using Maths.Api.Services.Tokens;

namespace Maths.Api.Services.Evaluators;

/// <summary>
/// Evaluate postfix expressions
/// </summary>
public class EvaluatePostfixExpression : IEvaluator
{
    /// <summary>
    /// Evaluate expression to a double result
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    /// <exception cref="EvaluationException"></exception>
    public Expression Evaluate(Expression expression)
    {
        if (expression.Type != ExpressionType.Postfix)
        {
            throw new EvaluateException(
                "Failed to evaluate expression: incorrect format"
            );
        }
        
        var evaluatedTokens = new Stack<NumberToken>();

        foreach (var token in expression.Tokens)
        {
            switch (token)
            {
                case NumberToken numberToken:
                    evaluatedTokens.Push(numberToken);
                    break;
                case OperatorToken when evaluatedTokens.Count < 2:
                    throw new EvaluationException(
                        "Failed to evaluate expression: syntax error");
                case OperatorToken operatorToken:
                    var firstNumber = evaluatedTokens.Pop();
                    var secondNumber = evaluatedTokens.Pop();
                    evaluatedTokens.Push(new NumberToken(Evaluate(operatorToken, firstNumber, secondNumber)));
                    break;
            }
        }

        if (evaluatedTokens.Count != 1)
        {
            throw new EvaluationException(
                "Failed to evaluate expression: syntax error");
        }

        return new Expression(new List<IToken>()
        {
            evaluatedTokens.First()
        }, ExpressionType.SingleNumber);
    }

    /// <summary>
    /// Apply an operator to two number tokens
    /// </summary>
    /// <param name="operatorToken"></param>
    /// <param name="firstNumber"></param>
    /// <param name="secondNumber"></param>
    /// <returns></returns>
    /// <exception cref="EvaluationException"></exception>
    private static double Evaluate(OperatorToken operatorToken, NumberToken firstNumber, NumberToken secondNumber)
    {
        return operatorToken.Type switch
        {
            OperatorType.AdditionOperator => firstNumber.Value + secondNumber.Value,
            OperatorType.MultiplicationOperator => firstNumber.Value * secondNumber.Value,
            OperatorType.SubtractionOperator => secondNumber.Value - firstNumber.Value,
            OperatorType.DivisionOperator => secondNumber.Value / firstNumber.Value , 
            _ => throw new EvaluationException("Failed to evaluate expression: unknown operator type")
        };
    }
}