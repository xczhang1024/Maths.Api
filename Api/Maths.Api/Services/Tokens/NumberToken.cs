using Maths.Api.Exceptions;

namespace Maths.Api.Services.Tokens;

/// <summary>
/// Token that represents a number
/// </summary>
public class NumberToken : IToken
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="value"></param>
    public NumberToken(double value)
    {
        Value = value;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="value"></param>
    public NumberToken(string value)
    {
        if (string.IsNullOrEmpty(value)
            || string.IsNullOrWhiteSpace(value)
            || !double.TryParse(value, out var num))
        {
            throw new ConvertToInfixExpressionException(
                $"{value} : is not a number");
        }

        Value = num;
    }

    /// <summary>
    /// To string
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{Value}";
    }

    /// <summary>
    /// Value of number
    /// </summary>
    public double Value { get; }
}