namespace Maths.Api.Exceptions;

/// <summary>
/// Exception when converting string to tokens
/// </summary>
public class TokenConversionException : Exception
{
    public TokenConversionException()
    {
    }
    
    public TokenConversionException(string message) : base(message)
    {
    }
    
    public TokenConversionException(string message, Exception innerException) : base(message, innerException)
    {
    }
}