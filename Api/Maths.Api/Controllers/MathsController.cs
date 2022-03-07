using Maths.Api.DataAccess;
using Maths.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Maths.Api.Controllers;

/// <summary>
/// Api controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class MathsController : ControllerBase
{
    /// <summary>
    /// The service
    /// </summary>
    private readonly IMathsService _service;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="service"></param>
    public MathsController(IMathsService service)
    {
        _service = service;
    }
    
    /// <summary>
    /// Evaluate expression
    /// </summary>
    /// <param name="expressionDto">Contains expression to evaluate</param>
    /// <returns></returns>
    [HttpPost]
    [Route("Expression/Evaluate")]
    public async Task<IActionResult> EvaluateExpression(InputExpressionDto expressionDto)
    {
        return await _service.EvaluateExpression(expressionDto);
    }
}