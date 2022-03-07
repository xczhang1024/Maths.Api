using Maths.Api.Exceptions;
using Maths.Api.Services.Tokens;

namespace Maths.Api.Services.Converters;

/// <summary>
/// Convert infix notation to postfix notation
/// </summary>
public class PostfixNotationConverter : IPostfixNotationConverter
{
    /// <summary>
    /// Convert infix tokens to postfix
    /// </summary>
    /// <param name="infixTokens"></param>
    /// <returns></returns>
    public PostfixExpression Convert(List<IToken> infixTokens)
    {
        var operatorTokens = new Stack<OperatorToken>();
        var result = new List<IToken>();

        foreach (var token in infixTokens)
        {
            ProcessToken(token, operatorTokens, result);
        }
        
        // Pop off the remaining operators and add to result
        while (operatorTokens.Count > 0)
        {
            result.Add(operatorTokens.Pop());
        }

        return new PostfixExpression(result);
    }

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
                throw new PostfixConversionException($"Unhandled token {token}");
        }
    }

    private void StoreNumberToken(NumberToken numberToken, ICollection<IToken> result)
    {
        result.Add(numberToken);
    }
    
    private void StoreOperatorToken(OperatorToken operatorToken, 
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