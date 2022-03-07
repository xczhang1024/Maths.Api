using Maths.Api.Enums;
using Maths.Api.Exceptions;
using Maths.Api.Services.Expressions;
using Maths.Api.Services.Tokens;

namespace Maths.Api.Services.Evaluators;

/// <summary>
/// Evaluator for postfix expressions
/// </summary>
public class PostfixExpressionEvaluator : IPostfixExpressionEvaluator
{
    /// <summary>
    /// Evaluate postfix expression to a double result
    /// </summary>
    /// <param name="postFixExpression"></param>
    /// <returns></returns>
    public double Evaluate(PostfixExpression postFixExpression)
    {
        var evaluatedTokens = new Stack<NumberToken>();

        foreach (var token in postFixExpression.Tokens)
        {
            switch (token)
            {
                case NumberToken numberToken:
                    evaluatedTokens.Push(numberToken);
                    break;
                case OperatorToken when evaluatedTokens.Count < 2:
                    throw new PostfixExpressionEvaluationException(
                        $"Failed to evaluate expression {postFixExpression}");
                case OperatorToken operatorToken:
                    var firstNumber = evaluatedTokens.Pop();
                    var secondNumber = evaluatedTokens.Pop();
                    evaluatedTokens.Push(new NumberToken(Evaluate(operatorToken, firstNumber, secondNumber)));
                    break;
            }
        }

        if (evaluatedTokens.Count != 1)
        {
            throw new PostfixExpressionEvaluationException(
                $"Failed to evaluate expression {postFixExpression}");
        }

        return evaluatedTokens.Pop().Value;
    }

    /// <summary>
    /// Apply an operator to two number tokens
    /// </summary>
    /// <param name="operatorToken"></param>
    /// <param name="firstNumber"></param>
    /// <param name="secondNumber"></param>
    /// <returns></returns>
    /// <exception cref="PostfixExpressionEvaluationException"></exception>
    private static double Evaluate(OperatorToken operatorToken, NumberToken firstNumber, NumberToken secondNumber)
    {
        return operatorToken.Type switch
        {
            OperatorType.AdditionOperator => firstNumber.Value + secondNumber.Value,
            OperatorType.MultiplicationOperator => firstNumber.Value * secondNumber.Value,
            OperatorType.SubtractionOperator => secondNumber.Value - firstNumber.Value,
            OperatorType.DivisionOperator => secondNumber.Value / firstNumber.Value , 
            _ => throw new PostfixExpressionEvaluationException($"Operator type: {operatorToken.Type} is unknown")
        };
    }
}