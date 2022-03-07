using System.Collections.Generic;
using Maths.Api.Enums;
using Maths.Api.Exceptions;
using Maths.Api.Services.Evaluators;
using Maths.Api.Services.Tokens;
using Xunit;

namespace Maths.Api.Tests;

public class PostfixExpressionEvaluatorShould
{
    [Fact]
    public void CorrectlySolveSimplePostfixExpression()
    {
        var tokens = new List<IToken>()
        {
            new NumberToken(3),
            new NumberToken(4),
            new OperatorToken(OperatorType.AdditionOperator),
        };

        var sut = new PostfixExpressionEvaluator();
        var result = sut.Evaluate(new PostfixExpression(tokens));
        
        Assert.Equal(7, result);
    }
    
    [Fact]
    public void CorrectlySolvePostfixExpressionWithPrecedence()
    {
        var tokens = new List<IToken>()
        {
            new NumberToken(3),
            new NumberToken(4),
            new NumberToken(2),
            new OperatorToken(OperatorType.DivisionOperator),
            new OperatorToken(OperatorType.AdditionOperator)
        };

        var sut = new PostfixExpressionEvaluator();
        var result = sut.Evaluate(new PostfixExpression(tokens));
        
        Assert.Equal(5, result);
    }

    [Fact]
    public void CorrectlySolveComplexPostfixExpression()
    {
        var tokens = new List<IToken>()
        {
            new NumberToken(3),
            new NumberToken(4),
            new NumberToken(2),
            new OperatorToken(OperatorType.MultiplicationOperator),
            new OperatorToken(OperatorType.AdditionOperator),
            new NumberToken(5),
            new OperatorToken(OperatorType.SubtractionOperator)
        };
        
        var sut = new PostfixExpressionEvaluator();
        var result = sut.Evaluate(new PostfixExpression(tokens));
        
        Assert.Equal(6, result);
    }

    [Fact]
    public void CorrectlyThrowsEvaluationException()
    {
        var tokens = new List<IToken>()
        {
            new NumberToken(3),
            new NumberToken(4),
            new NumberToken(2),
            new OperatorToken(OperatorType.MultiplicationOperator)
        };
        
        var sut = new PostfixExpressionEvaluator();

        var ex = Assert
            .Throws<PostfixEvaluationException>(()
                => sut.Evaluate(new PostfixExpression(tokens)));
        
        Assert.Equal($"Failed to evaluate expression {new PostfixExpression(tokens)}", ex.Message);
    }
}