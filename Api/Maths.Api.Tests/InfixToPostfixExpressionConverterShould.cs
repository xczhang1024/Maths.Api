using System.Collections.Generic;
using Maths.Api.Enums;
using Maths.Api.Services.Converters;
using Maths.Api.Services.Expressions;
using Maths.Api.Services.Tokens;
using Xunit;

namespace Maths.Api.Tests;

public class InfixToPostfixExpressionConverterShould
{
    [Fact]
    public void CorrectlyConvertThreePlusFourToPostfixNotation()
    {
        var infixExpression = new InfixExpression(new List<IToken>()
        {
            new NumberToken(3),
            new OperatorToken(OperatorType.AdditionOperator),
            new NumberToken(4)
        });

        var sut = new InfixToPostfixExpressionConverter();
        var result = sut.ConvertToPostfixExpression(infixExpression).ToString();

        Assert.Equal("3 4 +", result);
    }
    
    [Fact]
    public void CorrectlyConvertThreePlusFourDivideByTwoToPostfixNotation()
    {
        var infixExpression = new InfixExpression(new List<IToken>()
        {
            new NumberToken(3),
            new OperatorToken(OperatorType.AdditionOperator),
            new NumberToken(4),
            new OperatorToken(OperatorType.DivisionOperator),
            new NumberToken(2)
        });
        
        var sut = new InfixToPostfixExpressionConverter();
        var result = sut.ConvertToPostfixExpression(infixExpression).ToString();

        Assert.Equal("3 4 2 / +", result);
    }
    
    [Fact]
    public void CorrectlyConvertThreePlusFourTimesTwoMinusFiveDivideByThreeToPostfixNotation()
    {
        var infixExpression = new InfixExpression(new List<IToken>()
        {
            new NumberToken(3),
            new OperatorToken(OperatorType.AdditionOperator),
            new NumberToken(4),
            new OperatorToken(OperatorType.MultiplicationOperator),
            new NumberToken(2),
            new OperatorToken(OperatorType.SubtractionOperator),
            new NumberToken(5),
            new OperatorToken(OperatorType.DivisionOperator),
            new NumberToken(3),
        });
        
        var sut = new InfixToPostfixExpressionConverter();
        var result = sut.ConvertToPostfixExpression(infixExpression).ToString();

        Assert.Equal("3 4 2 * + 5 3 / -", result);
    }
}