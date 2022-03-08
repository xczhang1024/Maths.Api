using Maths.Api.DataAccess;
using Maths.Api.Exceptions;
using Maths.Api.Services.Converters;
using Maths.Api.Services.Evaluators;
using Microsoft.AspNetCore.Mvc;

namespace Maths.Api.Services;

/// <summary>
/// Service for Maths controller
/// </summary>
public class MathsService : IMathsService
{
    private readonly IConverterRunner _converterRunner;

    private readonly IEvaluator _evaluator;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="converterRunner"></param>
    /// <param name="evaluator"></param>
    public MathsService(IConverterRunner converterRunner, IEvaluator evaluator)
    {
        _evaluator = evaluator;
        _converterRunner = converterRunner;
    }

    /// <summary>
    /// Evaluate expression
    /// </summary>
    /// <param name="expressionDto"></param>
    /// <returns></returns>
    public IActionResult EvaluateExpression(InputExpressionDto expressionDto)
    {
        try
        {
            var expression = _converterRunner.RunConverters(expressionDto.Expression);
            var result = _evaluator.Evaluate(expression);

            return new OkObjectResult(new SuccessDto(result));
        }
        catch (Exception ex)
        {
            if (ex is ConversionException 
                or EvaluationException)
            {
                return new UnprocessableEntityObjectResult(
                    new ErrorDto("The input is invalid. Reason: " + ex.Message, 
                        ex.Message));
            }
            
            return new BadRequestObjectResult(
                new ErrorDto("An error occurred while evaluating the input", 
                ex.Message));
        }
    }
}