using Maths.Api.Services.Expressions;

namespace Maths.Api.Services.Converters;

/// <summary>
/// Step for converting string to expression
/// </summary>
public interface IConvertFromString
{
    /// <summary>
    /// Convert string to expression
    /// </summary>
    /// <param name="expressionString"></param>
    /// <returns></returns>
    Expression Convert(string expressionString);
}