namespace Maths.Api.Exceptions;

/// <summary>
/// Exception from evaluating the result of a postfix expression
/// </summary>
public class PostfixExpressionEvaluationException : Exception
{
    public PostfixExpressionEvaluationException()
    {
    }
    
    public PostfixExpressionEvaluationException(string message) 
        : base(message)
    {
    }
    
    public PostfixExpressionEvaluationException(string message, Exception innerException) 
        : base(message, innerException)
    {
    }
}