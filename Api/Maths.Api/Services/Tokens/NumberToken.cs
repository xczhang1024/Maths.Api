using System.Globalization;

namespace Maths.Api.Services.Tokens;

/// <summary>
/// Represents a number
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