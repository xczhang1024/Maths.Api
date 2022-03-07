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
    /// Endpoint to evaluate an expression
    /// </summary>
    /// <param name="expressionDto">Contains expression to evaluate</param>
    /// <returns></returns>
    [HttpPost]
    [Route("expression/evaluate")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDto))]
    public IActionResult EvaluateExpression(InputExpressionDto expressionDto)
    {
        return _service.EvaluateExpression(expressionDto);
    }
}