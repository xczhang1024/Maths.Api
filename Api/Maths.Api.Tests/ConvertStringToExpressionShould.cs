using System.Collections.Generic;
using Maths.Api.DataAccess;
using Maths.Api.Enums;
using Maths.Api.Exceptions;
using Maths.Api.Services.Converters;
using Maths.Api.Services.Expressions;
using Maths.Api.Services.Tokens;
using Xunit;

namespace Maths.Api.Tests;

public class ConvertStringToExpressionShould
{
    [Fact]
    public void CorrectlyConvertThreePlusFourToInfixExpression()
    {
        var threePlusFourExpression = new InputExpressionDto("3+4");
        var infixExpression = new Expression(new List<IToken>()
        {
            new NumberToken(3),
            new OperatorToken('+'),
            new NumberToken(4)
        }, ExpressionType.Infix);

        var sut = new ConvertStringToExpression();
        var expression = sut.Convert(threePlusFourExpression.Expression);
        
        Assert.Equal(infixExpression.ToString(), expression.ToString());
        Assert.Equal(ExpressionType.Infix, expression.Type);
    }

    [Fact]
    public void CorrectlyConvertThreePlusFourDivideByTwoToInfixExpression()
    {
        var threePlusFourDivideByTwoExpression = new InputExpressionDto("3 + 4 / 2");
        var infixExpression = new Expression(new List<IToken>()
        {
            new NumberToken(3),
            new OperatorToken('+'),
            new NumberToken(4),
            new OperatorToken('/'),
            new NumberToken(2)
        }, ExpressionType.Infix);
        
        var sut = new ConvertStringToExpression();
        var expression = sut.Convert(threePlusFourDivideByTwoExpression.Expression);
        
        Assert.Equal(infixExpression.ToString(), expression.ToString());
        Assert.Equal(ExpressionType.Infix, expression.Type);
    }

    [Fact]
    public void CorrectlyConvertThreePlusFourTimesTwoMinusFiveDivideByThreeToInfixExpression()
    {
        var threePlusFourTimesTwoMinusFiveDividedByThreeExpression = new InputExpressionDto("3 + 4* 2- 5/3");
        var infixExpression = new Expression(new List<IToken>()
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
        }, ExpressionType.Infix);
        
        var sut = new ConvertStringToExpression();
        var expression = sut.Convert(threePlusFourTimesTwoMinusFiveDividedByThreeExpression.Expression);
        
        Assert.Equal(infixExpression.ToString(), expression.ToString());
        Assert.Equal(ExpressionType.Infix, expression.Type);
    }
    
    [Fact]
    public void ThrowsConvertToInfixExpressionExceptionWhenStringStartsWithOperator()
    {
        var startsWithOperatorExpression = new InputExpressionDto("+3+7");
        
        var sut = new ConvertStringToExpression();
        
        var ex = Assert
            .Throws<ConversionException>(()
                => sut.Convert(startsWithOperatorExpression.Expression));
        
        Assert.Equal(
            "Failed to convert expression: the input should not begin or end with an operator: +-*/", 
            ex.Message);
    }
    
    [Fact]
    public void ThrowsConvertToInfixExpressionExceptionWhenStringEndsWithOperator()
    {
        var endsWithOperatorExpression = new InputExpressionDto("3+7/");
        
        var sut = new ConvertStringToExpression();
        
        var ex = Assert
            .Throws<ConversionException>(()
                => sut.Convert(endsWithOperatorExpression.Expression));
        
        Assert.Equal(
            "Failed to convert expression: the input should not begin or end with an operator: +-*/", 
            ex.Message);
    }
    
    [Fact]
    public void ThrowsConvertToInfixExpressionExceptionWhenStringIsLessThanThreeCharactersLong()
    {
        var tooShortExpression = new InputExpressionDto("4+");
        
        var sut = new ConvertStringToExpression();
        
        var ex = Assert
            .Throws<ConversionException>(()
                => sut.Convert(tooShortExpression.Expression));
        
        Assert.Equal(
            "Failed to convert expression: the input should be at least 3 characters long", 
            ex.Message);
    }
    
    [Fact]
    public void ThrowsConvertToInfixExpressionExceptionWhenStringIsWhitespace()
    {
        var whitespaceExpression = new InputExpressionDto("  \r\n");
        
        var sut = new ConvertStringToExpression();
        
        var ex = Assert
            .Throws<ConversionException>(()
                => sut.Convert(whitespaceExpression.Expression));
        
        Assert.Equal(
            "Failed to convert expression: the input is empty", 
            ex.Message);
    }

    [Fact]
    public void ThrowsConvertToInfixExpressionExceptionWhenStringContainsNegativeNumbers()
    {
        var whitespaceExpression = new InputExpressionDto("1 + 2/1.5 * -3.7777");
        
        var sut = new ConvertStringToExpression();
        
        var ex = Assert
            .Throws<ConversionException>(()
                => sut.Convert(whitespaceExpression.Expression));
        
        Assert.Equal(
            "Failed to convert expression: " +
            "the input should contain only positive numbers and +-*/ characters", 
            ex.Message);
    }
}