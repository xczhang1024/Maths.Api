using Maths.Api.Services.Expressions;

namespace Maths.Api.Services.Evaluators;

/// <summary>
/// Evaluator runner
/// </summary>
public class EvaluatorRunner : IEvaluatorRunner
{
    /// <summary>
    /// List of evaluators
    /// </summary>
    private readonly IEnumerable<IEvaluator> _evaluators;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="evaluators"></param>
    public EvaluatorRunner(IEnumerable<IEvaluator> evaluators)
    {
        _evaluators = evaluators;
    }
    
    /// <summary>
    /// Run all evaluators
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public Expression Run(Expression expression)
    {
        expression = _evaluators.Aggregate(expression, 
            (current, evaluator) => evaluator.Evaluate(current));

        return expression;
    }
}