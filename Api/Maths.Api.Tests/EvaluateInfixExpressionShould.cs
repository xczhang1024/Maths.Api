using System.Collections.Generic;
using Maths.Api.Enums;
using Maths.Api.Exceptions;
using Maths.Api.Services.Evaluators;
using Maths.Api.Services.Expressions;
using Maths.Api.Services.Tokens;
using Xunit;

namespace Maths.Api.Tests;

public class EvaluateInfixExpressionShould
{
    [Fact]
    public void ThrowEvaluationExceptionWhenExpressionIsNotInfix()
    {
        var postFixExpression = new Expression(new List<IToken>()
        {
            new NumberToken(3),
            new NumberToken(4),
            new OperatorToken(OperatorType.AdditionOperator),
        }, ExpressionType.Postfix);
        
        var sut = new EvaluateInfixExpression();
        
        var ex = Assert
            .Throws<EvaluationException>(()
                => sut.Evaluate(postFixExpression));
        
        Assert.Equal(
            "Failed to evaluate expression: the expression has incorrect expression type", 
            ex.Message);
    }
    
    [Fact]
    public void CorrectlyEvaluateThreePlusFourToPostfixNotation()
    {
        var infixExpression = new Expression(new List<IToken>()
        {
            new NumberToken(3),
            new OperatorToken(OperatorType.AdditionOperator),
            new NumberToken(4)
        }, ExpressionType.Infix);

        var sut = new EvaluateInfixExpression();
        var result = sut.Evaluate(infixExpression);

        Assert.Equal("3 4 +", result.ToString());
        Assert.Equal(ExpressionType.Postfix, result.Type);
    }
    
    [Fact]
    public void CorrectlyEvaluateThreePlusFourDivideByTwoToPostfixNotation()
    {
        var infixExpression = new Expression(new List<IToken>()
        {
            new NumberToken(3),
            new OperatorToken(OperatorType.AdditionOperator),
            new NumberToken(4),
            new OperatorToken(OperatorType.DivisionOperator),
            new NumberToken(2)
        }, ExpressionType.Infix);
        
        var sut = new EvaluateInfixExpression();
        var result = sut.Evaluate(infixExpression);

        Assert.Equal("3 4 2 / +", result.ToString());
        Assert.Equal(ExpressionType.Postfix, result.Type);
    }
    
    [Fact]
    public void CorrectlyEvaluateThreePlusFourTimesTwoMinusFiveDivideByThreeToPostfixNotation()
    {
        var infixExpression = new Expression(new List<IToken>()
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
        }, ExpressionType.Infix);
        
        var sut = new EvaluateInfixExpression();
        var result = sut.Evaluate(infixExpression);

        Assert.Equal("3 4 2 * + 5 3 / -", result.ToString());
        Assert.Equal(ExpressionType.Postfix, result.Type);
    }
}