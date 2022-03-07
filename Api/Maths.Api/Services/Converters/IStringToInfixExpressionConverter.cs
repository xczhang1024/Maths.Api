using Maths.Api.DataAccess;
using Maths.Api.Services.Expressions;

namespace Maths.Api.Services.Converters;

/// <summary>
/// Convert string to infix expression
/// </summary>
public interface IStringToInfixExpressionConverter
{
    /// <summary>
    /// Convert string to infix expression
    /// </summary>
    /// <param name="inputExpressionDto"></param>
    /// <returns></returns>
    InfixExpression ConvertToInfixExpression(InputExpressionDto inputExpressionDto);
}