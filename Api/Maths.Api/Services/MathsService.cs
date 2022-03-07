using Maths.Api.DataAccess;
using Maths.Api.Services.Converters;
using Maths.Api.Services.Evaluators;
using Microsoft.AspNetCore.Mvc;

namespace Maths.Api.Services;

/// <summary>
/// Maths Api service
/// </summary>
public class MathsService : IMathsService
{
    /// <summary>
    /// String to tokens converter
    /// </summary>
    private readonly IStringToTokensConverter _stringToTokensConverter;

    /// <summary>
    /// Convert tokens from infix to postfix notation
    /// </summary>
    private readonly IPostfixNotationConverter _postfixNotationConverter;

    /// <summary>
    /// Evaluate the result of postfix expression
    /// </summary>
    private readonly IPostfixExpressionEvaluator _postfixExpressionEvaluator;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="stringToTokensConverter"></param>
    /// <param name="postfixNotationConverter"></param>
    /// <param name="postfixExpressionEvaluator"></param>
    public MathsService(IStringToTokensConverter stringToTokensConverter, 
        IPostfixNotationConverter postfixNotationConverter, 
        IPostfixExpressionEvaluator postfixExpressionEvaluator)
    {
        _stringToTokensConverter = stringToTokensConverter;
        _postfixNotationConverter = postfixNotationConverter;
        _postfixExpressionEvaluator = postfixExpressionEvaluator;
    }

    /// <summary>
    /// Evaluate expression
    /// </summary>
    /// <param name="expressionDto"></param>
    /// <returns></returns>
    public async Task<IActionResult> EvaluateExpression(InputExpressionDto expressionDto)
    {
        return new OkObjectResult(new ResultDto(5));
    }
}