using Maths.Api.Services.Tokens;

namespace Maths.Api.Services.Converters;

/// <summary>
/// Convert infix notation to postfix notation
/// </summary>
public interface IPostfixNotationConverter
{
    /// <summary>
    /// Convert infix tokens to postfix
    /// </summary>
    /// <param name="infixTokens"></param>
    /// <returns></returns>
    PostfixExpression Convert(List<IToken> infixTokens);
}