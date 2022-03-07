using Maths.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Maths.Api.Controllers;

/// <summary>
/// Api controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class MathsApiController : ControllerBase
{
    /// <summary>
    /// The service
    /// </summary>
    private readonly IMathsApiService _service;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="service"></param>
    public MathsApiController(IMathsApiService service)
    {
        _service = service;
    }
}