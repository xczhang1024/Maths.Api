using System.Collections.Generic;
using Maths.Api.Enums;
using Maths.Api.Exceptions;
using Maths.Api.Services.Evaluators;
using Maths.Api.Services.Expressions;
using Maths.Api.Services.Tokens;
using Xunit;

namespace Maths.Api.Tests;

public class EvaluatePostfixExpressionShould
{
    [Fact]
    public void CorrectlySolveThreePlusFour()
    {
        var expression = new Expression(new List<IToken>()
        {
            new NumberToken(3),
            new NumberToken(4),
            new OperatorToken(OperatorType.AdditionOperator),
        }, ExpressionType.Postfix);

        const double correctAnswer = 3 + 4;

        var sut = new EvaluatePostfixExpression();
        var result = sut.Evaluate(expression);
        
        Assert.Equal(correctAnswer, result);
    }
    
    [Fact]
    public void CorrectlySolveThreePlusFourDivideByTwo()
    {
        var expression = new Expression(new List<IToken>()
        {
            new NumberToken(3),
            new NumberToken(4),
            new NumberToken(2),
            new OperatorToken(OperatorType.DivisionOperator),
            new OperatorToken(OperatorType.AdditionOperator)
        }, ExpressionType.Postfix);

        const double correctAnswer = 3 + 4 / 2;

        var sut = new EvaluatePostfixExpression();
        var result = sut.Evaluate(expression);
        
        Assert.Equal(correctAnswer, result);
    }

    [Fact]
    public void CorrectlySolveThreePlusFourTimesTwoMinusFiveDivideByThree()
    {
        var expression = new Expression(new List<IToken>()
        {
            new NumberToken(3),
            new NumberToken(4),
            new NumberToken(2),
            new OperatorToken(OperatorType.MultiplicationOperator),
            new OperatorToken(OperatorType.AdditionOperator),
            new NumberToken(5),
            new NumberToken(3),
            new OperatorToken(OperatorType.DivisionOperator),
            new OperatorToken(OperatorType.SubtractionOperator)
        }, ExpressionType.Postfix);

        const double correctAnswer = 3 + 4 * 2 - 5.0d / 3;
        
        var sut = new EvaluatePostfixExpression();
        var result = sut.Evaluate(expression);
        
        Assert.Equal(correctAnswer, result);
    }

    [Fact]
    public void ThrowsEvaluationExceptionWhenThereAreMoreNumbersThanOperators()
    {
        var expression = new Expression(new List<IToken>()
        {
            new NumberToken(3),
            new NumberToken(4),
            new NumberToken(2),
            new OperatorToken(OperatorType.MultiplicationOperator)
        }, ExpressionType.Postfix);
        
        var sut = new EvaluatePostfixExpression();

        var ex = Assert
            .Throws<EvaluationException>(()
                => sut.Evaluate(expression));
        
        Assert.Equal("Failed to evaluate expression: syntax error", 
            ex.Message);
    }

    [Fact]
    public void ThrowsEvaluationExceptionWithOneNumberAndOneOperator()
    {
        var expression = new Expression(new List<IToken>()
        {
            new NumberToken(3),
            new OperatorToken(OperatorType.AdditionOperator)
        }, ExpressionType.Postfix);
        
        var sut = new EvaluatePostfixExpression();

        var ex = Assert
            .Throws<EvaluationException>(()
                => sut.Evaluate(expression));
        
        Assert.Equal("Failed to evaluate expression: syntax error", 
            ex.Message);
    }
    
    [Fact]
    public void ThrowsEvaluationExceptionWithTwoOperators()
    {
        var expression = new Expression(new List<IToken>()
        {
            new NumberToken(3),
            new OperatorToken(OperatorType.AdditionOperator),
            new OperatorToken(OperatorType.SubtractionOperator),
            new NumberToken(5)
        }, ExpressionType.Postfix);
        
        var sut = new EvaluatePostfixExpression();

        var ex = Assert
            .Throws<EvaluationException>(()
                => sut.Evaluate(expression));
        
        Assert.Equal("Failed to evaluate expression: syntax error", 
            ex.Message);
    }
}