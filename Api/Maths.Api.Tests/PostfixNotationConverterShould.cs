using System.Collections.Generic;
using Maths.Api.Enums;
using Maths.Api.Exceptions;
using Maths.Api.Services;
using Maths.Api.Services.Converters;
using Maths.Api.Services.Tokens;
using Xunit;

namespace Maths.Api.Tests;

public class PostfixNotationConverterShould
{
    [Fact]
    public void ConvertSingleInfixExpressionToPostfix()
    {
        var tokens = new List<IToken>()
        {
            new NumberToken(3),
            new OperatorToken(OperatorType.AdditionOperator),
            new NumberToken(4)
        };
        
        var sut = new PostfixNotationConverter();
        var result = sut.Convert(tokens).ToString();

        Assert.Equal("3 4 +", result);
    }
    
    [Fact]
    public void ConvertExpressionWithPrecedenceToPostfix()
    {
        var tokens = new List<IToken>()
        {
            new NumberToken(3),
            new OperatorToken(OperatorType.AdditionOperator),
            new NumberToken(4),
            new OperatorToken(OperatorType.DivisionOperator),
            new NumberToken(2)
        };
        
        var sut = new PostfixNotationConverter();
        var result = sut.Convert(tokens).ToString();

        Assert.Equal("3 4 2 / +", result);
    }
    
    [Fact]
    public void ConvertComplexExpressionToPostfix()
    {
        var tokens = new List<IToken>()
        {
            new NumberToken(3),
            new OperatorToken(OperatorType.AdditionOperator),
            new NumberToken(4),
            new OperatorToken(OperatorType.MultiplicationOperator),
            new NumberToken(2),
            new OperatorToken(OperatorType.SubtractionOperator),
            new NumberToken(5)
        };
        
        var sut = new PostfixNotationConverter();
        var result = sut.Convert(tokens).ToString();

        Assert.Equal("3 4 2 * + 5 -", result);
    }
}