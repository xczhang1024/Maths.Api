namespace Maths.Api.Exceptions;

/// <summary>
/// Exception during converting infix tokens to postfix
/// </summary>
public class PostfixConversionException : Exception
{
    public PostfixConversionException()
    {
    }

    public PostfixConversionException(string message) : base(message)
    {
    }
    
    public PostfixConversionException(string message, Exception innerException) : base(message, innerException)
    {
    }
}