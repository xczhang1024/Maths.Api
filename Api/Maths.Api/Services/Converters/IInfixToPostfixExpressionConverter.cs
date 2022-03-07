using Maths.Api.Services.Expressions;

namespace Maths.Api.Services.Converters;

/// <summary>
/// Convert infix expression to postfix expression
/// </summary>
public interface IInfixToPostfixExpressionConverter
{
    /// <summary>
    /// Convert infix expression to postfix expression
    /// </summary>
    /// <param name="infixExpression"></param>
    /// <returns></returns>
    PostfixExpression ConvertToPostfixExpression(InfixExpression infixExpression);
}