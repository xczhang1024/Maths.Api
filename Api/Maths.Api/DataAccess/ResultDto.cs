namespace Maths.Api.DataAccess;

/// <summary>
/// Represents an output from Api
/// </summary>
public class ResultDto
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="result"></param>
    public ResultDto(double result)
    {
        Result = result;
    }
    
    /// <summary>
    /// Result
    /// </summary>
    public double Result { get; }
}