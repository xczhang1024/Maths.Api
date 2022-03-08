using Maths.Api.Enums;
using Maths.Api.Exceptions;

namespace Maths.Api.Services.Tokens;

/// <summary>
/// Represents an operator
/// </summary>
public class OperatorToken : IToken
{ 
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="type"></param>
    public OperatorToken(OperatorType type)
    {
        Type = type;
        SetPriority();
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="token"></param>
    public OperatorToken(char token)
    {
        SetType(token);
        SetPriority();
    }
    
    /// <summary>
    /// To string
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return Type switch
        {
            OperatorType.AdditionOperator => "+",
            OperatorType.SubtractionOperator => "-",
            OperatorType.MultiplicationOperator => "*",
            OperatorType.DivisionOperator => "/",
            _ => string.Empty
        };
    }

    /// <summary>
    /// Set token type
    /// </summary>
    /// <param name="token"></param>
    /// <exception cref="EvaluationException"></exception>
    private void SetType(char token)
    {
        Type = token switch
        {
            '+' => OperatorType.AdditionOperator,
            '-' => OperatorType.SubtractionOperator,
            '*' => OperatorType.MultiplicationOperator,
            '/' => OperatorType.DivisionOperator,
            _ => throw new EvaluationException( 
                $"Failed to evaluate expression: unhandled token: {token}")
        };
    }

    /// <summary>
    /// Set a value for priority
    /// Higher values mean higher priority
    /// </summary>
    /// <exception cref="EvaluationException"></exception>
    private void SetPriority()
    {
        switch (Type)
        {
            case OperatorType.AdditionOperator:
            case OperatorType.SubtractionOperator:
                Priority = 1;
                break;
            
            case OperatorType.MultiplicationOperator:
            case OperatorType.DivisionOperator:
                Priority = 2;
                break;
            default:
                throw new EvaluationException(
                    $"Failed to evaluate expression: unhandled operator type: {Type}");
        }
    }
    
    /// <summary>
    /// Token type
    /// </summary>
    public OperatorType Type { get; private set; }
    
    /// <summary>
    /// Priority of operator
    /// </summary>
    public int Priority { get; private set; }
}