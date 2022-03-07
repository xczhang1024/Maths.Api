namespace Maths.Api.DataAccess;

/// <summary>
/// Represents successful output from Api
/// </summary>
public class SuccessDto
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="result"></param>
    public SuccessDto(double result)
    {
        Result = result;
    }
    
    /// <summary>
    /// Result
    /// </summary>
    public double Result { get; }
}