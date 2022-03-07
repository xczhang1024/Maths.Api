using System.Collections.Generic;
using Maths.Api.Enums;
using Maths.Api.Exceptions;
using Maths.Api.Services.Evaluators;
using Maths.Api.Services.Expressions;
using Maths.Api.Services.Tokens;
using Xunit;

namespace Maths.Api.Tests;

public class PostfixExpressionEvaluatorShould
{
    [Fact]
    public void CorrectlySolveThreePlusFour()
    {
        var expression = new PostfixExpression(new List<IToken>()
        {
            new NumberToken(3),
            new NumberToken(4),
            new OperatorToken(OperatorType.AdditionOperator),
        });

        const double correctAnswer = 3 + 4;

        var sut = new PostfixExpressionEvaluator();
        var result = sut.Evaluate(expression);
        
        Assert.Equal(correctAnswer, result);
    }
    
    [Fact]
    public void CorrectlySolveThreePlusFourDivideByTwo()
    {
        var expression = new PostfixExpression(new List<IToken>()
        {
            new NumberToken(3),
            new NumberToken(4),
            new NumberToken(2),
            new OperatorToken(OperatorType.DivisionOperator),
            new OperatorToken(OperatorType.AdditionOperator)
        });

        const double correctAnswer = 3 + 4 / 2;

        var sut = new PostfixExpressionEvaluator();
        var result = sut.Evaluate(expression);
        
        Assert.Equal(correctAnswer, result);
    }

    [Fact]
    public void CorrectlySolveThreePlusFourTimesTwoMinusFiveDivideByThree()
    {
        var expression = new PostfixExpression(new List<IToken>()
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
        });

        const double correctAnswer = 3 + 4 * 2 - 5.0d / 3;
        
        var sut = new PostfixExpressionEvaluator();
        var result = sut.Evaluate(expression);
        
        Assert.Equal(correctAnswer, result);
    }

    [Fact]
    public void ThrowsEvaluationExceptionWhenThereAreMoreNumbersThanOperators()
    {
        var expression = new PostfixExpression(new List<IToken>()
        {
            new NumberToken(3),
            new NumberToken(4),
            new NumberToken(2),
            new OperatorToken(OperatorType.MultiplicationOperator)
        });
        
        var sut = new PostfixExpressionEvaluator();

        var ex = Assert
            .Throws<PostfixExpressionEvaluationException>(()
                => sut.Evaluate(expression));
        
        Assert.Equal($"Failed to evaluate expression {expression}", ex.Message);
    }

    [Fact]
    public void ThrowsEvaluationExceptionWithOneNumberAndOneOperator()
    {
        var expression = new PostfixExpression(new List<IToken>()
        {
            new NumberToken(3),
            new OperatorToken(OperatorType.AdditionOperator)
        });
        
        var sut = new PostfixExpressionEvaluator();

        var ex = Assert
            .Throws<PostfixExpressionEvaluationException>(()
                => sut.Evaluate(expression));
        
        Assert.Equal($"Failed to evaluate expression {expression}", ex.Message);
    }
    
    [Fact]
    public void ThrowsEvaluationExceptionWithTwoOperators()
    {
        var expression = new PostfixExpression(new List<IToken>()
        {
            new NumberToken(3),
            new OperatorToken(OperatorType.AdditionOperator),
            new OperatorToken(OperatorType.SubtractionOperator),
            new NumberToken(5)
        });
        
        var sut = new PostfixExpressionEvaluator();

        var ex = Assert
            .Throws<PostfixExpressionEvaluationException>(()
                => sut.Evaluate(expression));
        
        Assert.Equal($"Failed to evaluate expression {expression}", ex.Message);
    }
}