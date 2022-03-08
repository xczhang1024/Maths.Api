using Maths.Api.Enums;
using Maths.Api.Exceptions;
using Maths.Api.Services.Expressions;
using Maths.Api.Services.Tokens;

namespace Maths.Api.Services.Evaluators;

/// <summary>
/// Evaluate infix expression
/// </summary>
public class EvaluateInfixExpression : IEvaluator
{
    /// <summary>
    /// Evaluate infix expression as postfix expression
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    /// <exception cref="EvaluationException"></exception>
    public Expression Evaluate(Expression expression)
    {
        if (expression?.Tokens == null)
        {
            throw new EvaluationException(
                "Failed to evaluate expression: the expression was not provided");
        }

        if (expression.Type != ExpressionType.Infix)
        {
            throw new EvaluationException(
                "Failed to evaluate expression: the expression has incorrect expression type");
        }
        
        var operatorTokens = new Stack<OperatorToken>();
        var result = new List<IToken>();

        foreach (var token in expression.Tokens)
        {
            ProcessToken(token, operatorTokens, result);
        }
        
        // Pop off the remaining operators and add them at the end of results list
        while (operatorTokens.Count > 0)
        {
            result.Add(operatorTokens.Pop());
        }

        return new Expression(result, ExpressionType.Postfix);
    }

    /// <summary>
    /// Process the token
    /// </summary>
    /// <param name="token"></param>
    /// <param name="operatorTokens"></param>
    /// <param name="result"></param>
    /// <exception cref="EvaluationException"></exception>
    private void ProcessToken(IToken token, 
        Stack<OperatorToken> operatorTokens, ICollection<IToken> result)
    {
        switch (token)
        {
            case NumberToken numberToken:
                StoreNumberToken(numberToken, result);
                break;
            case OperatorToken operatorToken:
                StoreOperatorToken(operatorToken, operatorTokens, result);
                break;
            default:
                throw new EvaluationException(
                    "Failed to evaluate expression: found unknown token in expression");
        }
    }

    /// <summary>
    /// Store a number token
    /// Number tokens are simply added to the result list
    /// </summary>
    /// <param name="numberToken"></param>
    /// <param name="result"></param>
    private static void StoreNumberToken(NumberToken numberToken, ICollection<IToken> result)
    {
        result.Add(numberToken);
    }
    
    /// <summary>
    /// Store an operator token
    /// Ensure that token has highest priority
    /// Add tokens which are higher priority than the current token to the result
    /// They will be evaluated first
    /// </summary>
    /// <param name="operatorToken"></param>
    /// <param name="operatorTokens"></param>
    /// <param name="result"></param>
    private static void StoreOperatorToken(OperatorToken operatorToken, 
        Stack<OperatorToken> operatorTokens, ICollection<IToken> result)
    {
        while (operatorTokens.Count > 0)
        {
            var topToken = operatorTokens.Peek();

            if (topToken.Priority < operatorToken.Priority)
            {
                break;
            }
            
            result.Add(operatorTokens.Pop());
        }
        
        operatorTokens.Push(operatorToken);
    }
}