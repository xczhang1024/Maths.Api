namespace Maths.Api.Exceptions;

/// <summary>
/// Exception during converting infix expression to postfix expression
/// </summary>
public class ConvertToPostfixExpressionException : Exception
{
    public ConvertToPostfixExpressionException()
    {
    }

    public ConvertToPostfixExpressionException(string message) 
        : base(message)
    {
    }
    
    public ConvertToPostfixExpressionException(string message, Exception innerException) 
        : base(message, innerException)
    {
    }
}