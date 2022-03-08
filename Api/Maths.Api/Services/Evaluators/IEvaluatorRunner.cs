using Maths.Api.Services.Expressions;

namespace Maths.Api.Services.Evaluators;

/// <summary>
/// Evaluator runner
/// </summary>
public interface IEvaluatorRunner
{
    /// <summary>
    /// Run all evaluators
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    Expression Run(Expression expression);
}