using Maths.Api.DataAccess;
using Maths.Api.Services.Tokens;

namespace Maths.Api.Services.Converters;

/// <summary>
/// Convert string to tokens
/// </summary>
public class StringToTokensConverter : IStringToTokensConverter
{
    /// <summary>
    /// Convert to tokens
    /// </summary>
    /// <param name="inputExpressionDto"></param>
    /// <returns></returns>
    public List<IToken> Convert(InputExpressionDto inputExpressionDto)
    {
        return new List<IToken>();
    }
}