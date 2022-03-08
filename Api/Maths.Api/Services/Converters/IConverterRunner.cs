using Maths.Api.Services.Expressions;

namespace Maths.Api.Services.Converters;

/// <summary>
/// Conversion runner
/// </summary>
public interface IConverterRunner
{
    /// <summary>
    /// Run all converters from string to expression
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Expression RunConverters(string input);
}