using Maths.Api.Services.Expressions;

namespace Maths.Api.Services.Converters;

/// <summary>
/// Step for converting expression to expression
/// </summary>
public interface IConvertFromExpression
{
    /// <summary>
    /// Convert an expression to another expression
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    Expression Convert(Expression expression);
}