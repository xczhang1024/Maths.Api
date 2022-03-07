namespace Maths.Api.DataAccess;

/// <summary>
/// Error dto
/// </summary>
public class ErrorDto
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="exceptionMessage"></param>
    public ErrorDto(string message, string exceptionMessage)
    {
        Message = message;
        ExceptionMessage = exceptionMessage;
    }
    
    /// <summary>
    /// Error message
    /// </summary>
    public string Message { get; }
    
    /// <summary>
    /// Exception message
    /// </summary>
    public string ExceptionMessage { get; }
}