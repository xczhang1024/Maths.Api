using System.Collections.Generic;
using Maths.Api.DataAccess;
using Maths.Api.Exceptions;
using Maths.Api.Services.Converters;
using Maths.Api.Services.Expressions;
using Maths.Api.Services.Tokens;
using Xunit;

namespace Maths.Api.Tests;

public class StringToInfixExpressionConverterShould
{
    [Fact]
    public void CorrectlyConvertThreePlusFourToInfixExpression()
    {
        var threePlusFourExpression = new InputExpressionDto("3+4");
        var infixExpression = new InfixExpression(new List<IToken>()
        {
            new NumberToken(3),
            new OperatorToken('+'),
            new NumberToken(4)
        });

        var sut = new StringToInfixExpressionConverter();
        var expression = sut.ConvertToInfixExpression(threePlusFourExpression);
        
        Assert.Equal(infixExpression.ToString(), expression.ToString());
    }

    [Fact]
    public void CorrectlyConvertThreePlusFourDivideByTwoToInfixExpression()
    {
        var threePlusFourDivideByTwoExpression = new InputExpressionDto("3 + 4 / 2");
        var infixExpression = new InfixExpression(new List<IToken>()
        {
            new NumberToken(3),
            new OperatorToken('+'),
            new NumberToken(4),
            new OperatorToken('/'),
            new NumberToken(2)
        });
        
        var sut = new StringToInfixExpressionConverter();
        var expression = sut.ConvertToInfixExpression(threePlusFourDivideByTwoExpression);
        
        Assert.Equal(infixExpression.ToString(), expression.ToString());
    }

    [Fact]
    public void CorrectlyConvertThreePlusFourTimesTwoMinusFiveDivideByThreeToInfixExpression()
    {
        var threePlusFourTimesTwoMinusFiveDividedByThreeExpression = new InputExpressionDto("3 + 4* 2- 5/3");
        var infixExpression = new InfixExpression(new List<IToken>()
        {
            new NumberToken(3),
            new OperatorToken('+'),
            new NumberToken(4),
            new OperatorToken('*'),
            new NumberToken(2),
            new OperatorToken('-'),
            new NumberToken(5),
            new OperatorToken('/'),
            new NumberToken(3)
        });
        
        var sut = new StringToInfixExpressionConverter();
        var expression = sut.ConvertToInfixExpression(threePlusFourTimesTwoMinusFiveDividedByThreeExpression);
        
        Assert.Equal(infixExpression.ToString(), expression.ToString());
    }
    
    [Fact]
    public void ThrowsConvertToInfixExpressionExceptionWhenStringStartsWithOperator()
    {
        var startsWithOperatorExpression = new InputExpressionDto("+3+7");
        
        var sut = new StringToInfixExpressionConverter();
        
        var ex = Assert
            .Throws<ConvertToInfixExpressionException>(()
                => sut.ConvertToInfixExpression(startsWithOperatorExpression));
        
        Assert.Equal("Expression should not begin or end with an operator: +-*/", ex.Message);
    }
    
    [Fact]
    public void ThrowsConvertToInfixExpressionExceptionWhenStringEndsWithOperator()
    {
        var endsWithOperatorExpression = new InputExpressionDto("3+7/");
        
        var sut = new StringToInfixExpressionConverter();
        
        var ex = Assert
            .Throws<ConvertToInfixExpressionException>(()
                => sut.ConvertToInfixExpression(endsWithOperatorExpression));
        
        Assert.Equal("Expression should not begin or end with an operator: +-*/", ex.Message);
    }
    
    [Fact]
    public void ThrowsConvertToInfixExpressionExceptionWhenStringIsLessThanThreeCharactersLong()
    {
        var tooShortExpression = new InputExpressionDto("4+");
        
        var sut = new StringToInfixExpressionConverter();
        
        var ex = Assert
            .Throws<ConvertToInfixExpressionException>(()
                => sut.ConvertToInfixExpression(tooShortExpression));
        
        Assert.Equal("Expression should at least be 3 characters long", ex.Message);
    }
    
    [Fact]
    public void ThrowsConvertToInfixExpressionExceptionWhenStringIsWhitespace()
    {
        var whitespaceExpression = new InputExpressionDto("  \r\n");
        
        var sut = new StringToInfixExpressionConverter();
        
        var ex = Assert
            .Throws<ConvertToInfixExpressionException>(()
                => sut.ConvertToInfixExpression(whitespaceExpression));
        
        Assert.Equal("Expression should not be empty", ex.Message);
    }
}