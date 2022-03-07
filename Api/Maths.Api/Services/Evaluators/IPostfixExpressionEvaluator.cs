using Maths.Api.Services.Tokens;

namespace Maths.Api.Services.Evaluators;

/// <summary>
/// Evaluator for postfix expressions
/// </summary>
public interface IPostfixExpressionEvaluator
{
    /// <summary>
    /// Evaluate postfix expression to a double result
    /// </summary>
    /// <param name="postFixExpression"></param>
    /// <returns></returns>
    double Evaluate(PostfixExpression postFixExpression);
}