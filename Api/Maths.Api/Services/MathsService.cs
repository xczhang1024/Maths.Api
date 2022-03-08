using Maths.Api.DataAccess;
using Maths.Api.Enums;
using Maths.Api.Exceptions;
using Maths.Api.Services.Evaluators;
using Maths.Api.Services.Expressions;
using Maths.Api.Services.Tokens;
using Microsoft.AspNetCore.Mvc;

namespace Maths.Api.Services;

/// <summary>
/// Service for Maths controller
/// </summary>
public class MathsService : IMathsService
{
    private readonly IEvaluatorRunner _evaluatorRunner;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="evaluatorRunner"></param>
    public MathsService(IEvaluatorRunner evaluatorRunner)
    {
        _evaluatorRunner = evaluatorRunner;
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
            var inputExpression = new Expression(new List<IToken>()
            {
                new StringToken(expressionDto.Expression)
            }, ExpressionType.InfixString);

            var resultExpression = _evaluatorRunner.Run(inputExpression);

            return new OkObjectResult(new SuccessDto(
                double.Parse(resultExpression.ToString())));
        }
        catch (Exception ex)
        {
            if (ex is EvaluationException)
            {
                return new UnprocessableEntityObjectResult(
                    new ErrorDto("Invalid input: " + ex.Message, 
                        ex.Message));
            }
            
            return new BadRequestObjectResult(
                new ErrorDto("An error occurred while evaluating the input", 
                ex.Message));
        }
    }
}