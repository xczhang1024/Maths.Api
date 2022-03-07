using Maths.Api.Enums;

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
                throw new ArgumentOutOfRangeException(
                    $"Unhandled operator type {Type}");
        }
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
    /// Token type
    /// </summary>
    public OperatorType Type { get; }
    
    /// <summary>
    /// Priority of operator
    /// </summary>
    public int Priority { get; }
}