using System.Text;
using Maths.Api.Services.Tokens;

namespace Maths.Api.Services.Expressions;

/// <summary>
/// Holds an infix expression
/// </summary>
public class InfixExpression
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="tokens"></param>
    public InfixExpression(List<IToken> tokens)
    {
        Tokens = tokens;
    }
    
    /// <summary>
    /// Convert expression to string
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        var builder = new StringBuilder();

        foreach (var token in Tokens)
        {
            builder.Append($"{token} ");
        }
        
        return builder.ToString().Trim();
    }
    
    /// <summary>
    /// Tokens
    /// </summary>
    public List<IToken> Tokens { get; }
}