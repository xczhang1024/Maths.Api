using Maths.Api.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Maths.Api.Services;

/// <summary>
/// Service for Maths controller
/// </summary>
public interface IMathsService
{
    /// <summary>
    /// Evaluate expression
    /// </summary>
    /// <param name="expressionDto"></param>
    /// <returns></returns>
    IActionResult EvaluateExpression(InputExpressionDto expressionDto);
}