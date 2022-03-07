using System.ComponentModel.DataAnnotations;

namespace Maths.Api.DataAccess;

/// <summary>
/// Represents an input to Api
/// </summary>
public class InputExpressionDto
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="expression"></param>
    public InputExpressionDto(string expression)
    {
        Expression = expression;
    }
    
    /// <summary>
    /// Expression as string
    /// </summary>
    [Required]
    public string Expression { get; }
}