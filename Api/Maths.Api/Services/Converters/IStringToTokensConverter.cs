using Maths.Api.DataAccess;
using Maths.Api.Services.Tokens;

namespace Maths.Api.Services.Converters;

/// <summary>
/// Convert string to tokens
/// </summary>
public interface IStringToTokensConverter
{
    /// <summary>
    /// Convert to tokens
    /// </summary>
    /// <param name="inputExpressionDto"></param>
    /// <returns></returns>
    List<IToken> Convert(InputExpressionDto inputExpressionDto);
}