namespace Maths.Api.Enums;

/// <summary>
/// Types of expression
/// </summary>
public enum ExpressionType
{
    /// <summary>
    /// String expression as infix
    /// For example: "2+3"
    /// </summary>
    InfixString,
    
    /// <summary>
    /// One single number
    /// </summary>
    SingleNumber,
    
    /// <summary>
    /// Infix expression
    /// </summary>
    Infix,
    
    /// <summary>
    /// Postfix expression
    /// </summary>
    Postfix,
}