using Maths.Api.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Maths.Api.Services;

/// <summary>
/// Maths Api service
/// </summary>
public interface IMathsService
{
    /// <summary>
    /// Evaluate expression
    /// </summary>
    /// <param name="expressionDto"></param>
    /// <returns></returns>
    Task<IActionResult> EvaluateExpression(InputExpressionDto expressionDto);
}