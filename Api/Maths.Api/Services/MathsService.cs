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
    /// <summary>
    /// Convert string to infix expression
    /// </summary>
    private readonly IStringToInfixExpressionConverter _stringToInfixExpressionConverter;

    /// <summary>
    /// Convert infix expression to postfix expression
    /// </summary>
    private readonly IInfixToPostfixExpressionConverter _infixToPostfixExpressionConverter;

    /// <summary>
    /// Evaluate the result of postfix expression
    /// </summary>
    private readonly IPostfixExpressionEvaluator _postfixExpressionEvaluator;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="stringToInfixExpressionConverter"></param>
    /// <param name="infixToPostfixExpressionConverter"></param>
    /// <param name="postfixExpressionEvaluator"></param>
    public MathsService(IStringToInfixExpressionConverter stringToInfixExpressionConverter, 
        IInfixToPostfixExpressionConverter infixToPostfixExpressionConverter, 
        IPostfixExpressionEvaluator postfixExpressionEvaluator)
    {
        _stringToInfixExpressionConverter = stringToInfixExpressionConverter;
        _infixToPostfixExpressionConverter = infixToPostfixExpressionConverter;
        _postfixExpressionEvaluator = postfixExpressionEvaluator;
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
            var infixExpression = _stringToInfixExpressionConverter.ConvertToInfixExpression(expressionDto);
            var postfixExpression = _infixToPostfixExpressionConverter.ConvertToPostfixExpression(infixExpression);
            var result = _postfixExpressionEvaluator.Evaluate(postfixExpression);

            return new OkObjectResult(new SuccessDto(result));
        }
        catch (Exception ex)
        {
            if (ex is ConvertToInfixExpressionException 
                or ConvertToPostfixExpressionException 
                or PostfixExpressionEvaluationException)
            {
                return new UnprocessableEntityObjectResult(
                    new ErrorDto("The expression is invalid. Reason: " + ex.Message, 
                        ex.Message));
            }
            
            return new BadRequestObjectResult(
                new ErrorDto("An error occurred while evaluating the expression", 
                ex.Message));
        }
    }
}