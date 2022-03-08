namespace Maths.Api.Services.Tokens;

/// <summary>
/// String as a token
/// </summary>
public class StringToken : IToken
{
    /// <summary>
    /// String token
    /// </summary>
    /// <param name="value"></param>
    public StringToken(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Return as string
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return Value;
    }

    /// <summary>
    /// String value
    /// </summary>
    public string Value { get; }
}