using System.Text;
using Maths.Api.Enums;
using Maths.Api.Services.Tokens;

namespace Maths.Api.Services.Expressions;

/// <summary>
/// Represents an expression
/// </summary>
public class Expression
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="tokens"></param>
    /// <param name="type"></param>
    public Expression(List<IToken> tokens, ExpressionType type)
    {
        Tokens = tokens;
        Type = type;
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
    
    /// <summary>
    /// Expression type
    /// </summary>
    public ExpressionType Type { get; }
}