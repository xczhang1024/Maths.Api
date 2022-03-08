using Maths.Api.Services.Expressions;

namespace Maths.Api.Services.Converters;

/// <summary>
/// Conversion runner
/// </summary>
public class ConverterRunner : IConverterRunner
{
    /// <summary>
    /// Holds the converter from string to expression
    /// </summary>
    private readonly IConvertFromString _converterFromString;

    /// <summary>
    /// Holds the converter from expression to expression
    /// This could be extended into a list of converters between expressions
    /// </summary>
    private readonly IConvertFromExpression _converterFromExpression;
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="converterFromString"></param>
    /// <param name="converterFromExpression"></param>
    public ConverterRunner(IConvertFromString converterFromString, 
        IConvertFromExpression converterFromExpression)
    {
        _converterFromString = converterFromString;
        _converterFromExpression = converterFromExpression;
    }
    
    /// <summary>
    /// Run all conversions
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public Expression RunConverters(string input)
    {
        // First the input string must be converted to an expression
        var expression = _converterFromString.Convert(input);
        
        return _converterFromExpression.Convert(expression);
    }
}