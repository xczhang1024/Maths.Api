using Maths.Api.Exceptions;
using Maths.Api.Services.Expressions;
using Maths.Api.Services.Tokens;

namespace Maths.Api.Services.Converters;

/// <summary>
/// Convert infix expression to postfix expression
/// </summary>
public class InfixToPostfixExpressionConverter : IInfixToPostfixExpressionConverter
{
    /// <summary>
    /// Convert infix expression to postfix expression
    /// </summary>
    /// <param name="infixExpression"></param>
    /// <returns></returns>
    /// <exception cref="ConvertToPostfixExpressionException"></exception>
    public PostfixExpression ConvertToPostfixExpression(InfixExpression infixExpression)
    {
        if (infixExpression?.Tokens == null)
        {
            throw new ConvertToPostfixExpressionException("The expression was not provided");
        }
        
        var operatorTokens = new Stack<OperatorToken>();
        var result = new List<IToken>();

        foreach (var token in infixExpression.Tokens)
        {
            ProcessToken(token, operatorTokens, result);
        }
        
        // Pop off the remaining operators and add them at the end of results list
        while (operatorTokens.Count > 0)
        {
            result.Add(operatorTokens.Pop());
        }

        return new PostfixExpression(result);
    }

    /// <summary>
    /// Process the token
    /// </summary>
    /// <param name="token"></param>
    /// <param name="operatorTokens"></param>
    /// <param name="result"></param>
    /// <exception cref="ConvertToPostfixExpressionException"></exception>
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
                throw new ConvertToPostfixExpressionException($"The character: {token} is unknown");
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