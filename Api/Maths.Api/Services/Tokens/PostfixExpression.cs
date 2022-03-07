using System.Text;
using Microsoft.VisualBasic;

namespace Maths.Api.Services.Tokens;

/// <summary>
/// Represents a postfix expression
/// </summary>
public class PostfixExpression
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="tokens"></param>
    public PostfixExpression(List<IToken> tokens)
    {
        Tokens = tokens;
    }
    
    /// <summary>
    /// Convert to string
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        var builder = new StringBuilder();

        foreach (var token in Tokens)
        {
            builder.Append($"{token} ");
        }

        return Strings.Trim(builder.ToString());
    }
    
    /// <summary>
    /// Tokens in postfix
    /// </summary>
    public List<IToken> Tokens { get; }
}