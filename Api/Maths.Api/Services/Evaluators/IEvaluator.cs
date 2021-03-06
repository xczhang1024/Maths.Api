using Maths.Api.Services.Expressions;

namespace Maths.Api.Services.Evaluators;

/// <summary>
/// Interface for evaluating expression
/// </summary>
public interface IEvaluator
{
    /// <summary>
    /// Evaluate expression
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public Expression Evaluate(Expression expression);
}