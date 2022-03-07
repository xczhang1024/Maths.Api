namespace Maths.Api.Exceptions;

/// <summary>
/// Exception when converting string to infix expression
/// </summary>
public class ConvertToInfixExpressionException : Exception
{
    public ConvertToInfixExpressionException()
    {
    }
    
    public ConvertToInfixExpressionException(string message) 
        : base(message)
    {
    }
    
    public ConvertToInfixExpressionException(string message, Exception innerException) 
        : base(message, innerException)
    {
    }
}