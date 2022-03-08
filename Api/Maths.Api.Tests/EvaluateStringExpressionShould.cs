using System.Collections.Generic;
using Maths.Api.DataAccess;
using Maths.Api.Enums;
using Maths.Api.Exceptions;
using Maths.Api.Services.Evaluators;
using Maths.Api.Services.Expressions;
using Maths.Api.Services.Tokens;
using Xunit;

namespace Maths.Api.Tests;

public class EvaluateStringExpressionShould
{
    [Fact]
    public void CorrectlyEvaluateThreePlusFourToInfixExpression()
    {
        var threePlusFourExpression = new Expression(new List<IToken>()
        {
            new StringToken("3+4")
        }, ExpressionType.InfixString);
        
        var infixExpression = new Expression(new List<IToken>()
        {
            new NumberToken(3),
            new OperatorToken('+'),
            new NumberToken(4)
        }, ExpressionType.Infix);

        var sut = new EvaluateStringExpression();
        var expression = sut.Evaluate(threePlusFourExpression);
        
        Assert.Equal(infixExpression.ToString(), expression.ToString());
        Assert.Equal(ExpressionType.Infix, expression.Type);
    }

    [Fact]
    public void CorrectlyEvaluateThreePlusFourDivideByTwoToInfixExpression()
    {
        var threePlusFourDivideByTwoExpression = new Expression(new List<IToken>()
        {
            new StringToken("3 + 4 / 2")
        }, ExpressionType.InfixString);
        
        var infixExpression = new Expression(new List<IToken>()
        {
            new NumberToken(3),
            new OperatorToken('+'),
            new NumberToken(4),
            new OperatorToken('/'),
            new NumberToken(2)
        }, ExpressionType.Infix);
        
        var sut = new EvaluateStringExpression();
        var expression = sut.Evaluate(threePlusFourDivideByTwoExpression);
        
        Assert.Equal(infixExpression.ToString(), expression.ToString());
        Assert.Equal(ExpressionType.Infix, expression.Type);
    }

    [Fact]
    public void CorrectlyEvaluateThreePlusFourTimesTwoMinusFiveDivideByThreeToInfixExpression()
    {
        var threePlusFourTimesTwoMinusFiveDividedByThreeExpression = new Expression(new List<IToken>()
        {
            new StringToken("3 + 4* 2- 5/3")
        }, ExpressionType.InfixString);
        
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
        
        var sut = new EvaluateStringExpression();
        var expression = sut.Evaluate(threePlusFourTimesTwoMinusFiveDividedByThreeExpression);
        
        Assert.Equal(infixExpression.ToString(), expression.ToString());
        Assert.Equal(ExpressionType.Infix, expression.Type);
    }
    
    [Fact]
    public void ThrowsEvaluationExceptionExceptionWhenStringStartsWithOperator()
    {
        var startsWithOperatorExpression = new Expression(new List<IToken>()
        {
            new StringToken("+3+7")
        }, ExpressionType.InfixString);

        var sut = new EvaluateStringExpression();
        
        var ex = Assert
            .Throws<EvaluationException>(()
                => sut.Evaluate(startsWithOperatorExpression));
        
        Assert.Equal(
            "Failed to evaluate expression: the input should not begin or end with an operator: +-*/", 
            ex.Message);
    }
    
    [Fact]
    public void ThrowsEvaluationExceptionWhenStringEndsWithOperator()
    {
        var endsWithOperatorExpression = new Expression(new List<IToken>()
        {
            new StringToken("3+7/")
        }, ExpressionType.InfixString);

        var sut = new EvaluateStringExpression();
        
        var ex = Assert
            .Throws<EvaluationException>(()
                => sut.Evaluate(endsWithOperatorExpression));
        
        Assert.Equal(
            "Failed to evaluate expression: the input should not begin or end with an operator: +-*/", 
            ex.Message);
    }
    
    [Fact]
    public void ThrowsEvaluationExceptionWhenStringIsLessThanThreeCharactersLong()
    {
        var tooShortExpression = new Expression(new List<IToken>()
        {
            new StringToken("4+")
        }, ExpressionType.InfixString);

        var sut = new EvaluateStringExpression();
        
        var ex = Assert
            .Throws<EvaluationException>(()
                => sut.Evaluate(tooShortExpression));
        
        Assert.Equal(
            "Failed to evaluate expression: the input should be at least 3 characters long", 
            ex.Message);
    }
    
    [Fact]
    public void ThrowsEvaluationExceptionWhenStringIsWhitespace()
    {
        var whitespaceExpression = new Expression(new List<IToken>()
        {
            new StringToken("  \r\n")
        }, ExpressionType.InfixString);

        var sut = new EvaluateStringExpression();
        
        var ex = Assert
            .Throws<EvaluationException>(()
                => sut.Evaluate(whitespaceExpression));
        
        Assert.Equal(
            "Failed to evaluate expression: the input is empty", 
            ex.Message);
    }

    [Fact]
    public void ThrowsEvaluationExceptionWhenStringContainsNegativeNumbers()
    {
        var negativeNumbersExpression = new Expression(new List<IToken>()
        {
            new StringToken("1 + 2/1.5 * -3.7777")
        }, ExpressionType.InfixString);

        var sut = new EvaluateStringExpression();
        
        var ex = Assert
            .Throws<EvaluationException>(()
                => sut.Evaluate(negativeNumbersExpression));
        
        Assert.Equal(
            "Failed to evaluate expression: " +
            "the input should contain only positive numbers and +-*/ characters", 
            ex.Message);
    }
}