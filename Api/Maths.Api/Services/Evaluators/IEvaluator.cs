using Maths.Api.Services.Expressions;

namespace Maths.Api.Services.Evaluators;

/// <summary>
/// Interface for evaluating expression to a double result
/// </summary>
public interface IEvaluator
{
    /// <summary>
    /// Evaluate expression to a double result
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public double Evaluate(Expression expression);
}