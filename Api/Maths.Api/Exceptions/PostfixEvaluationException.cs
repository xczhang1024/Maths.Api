namespace Maths.Api.Exceptions;

/// <summary>
/// Exception from evaluating the result of a postfix expression
/// </summary>
public class PostfixEvaluationException : Exception
{
    public PostfixEvaluationException()
    {
    }
    
    public PostfixEvaluationException(string message) : base(message)
    {
    }
    
    public PostfixEvaluationException(string message, Exception innerException) : base(message, innerException)
    {
    }
}