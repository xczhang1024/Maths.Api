using System.Collections.Generic;
using Maths.Api.Enums;
using Maths.Api.Services.Converters;
using Maths.Api.Services.Expressions;
using Maths.Api.Services.Tokens;
using Xunit;

namespace Maths.Api.Tests;

public class ConverterRunnerShould
{
    [Fact]
    public void CorrectlyConvertThreePlusFourTimesTwoMinusFiveDivideByThreeFromStringInput()
    {
        const string stringExpression = "3 + 4*2 - 5/3";
        
        var correctAnswer = new Expression(new List<IToken>()
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

        var convertStringToExpression = new ConvertStringToExpression();
        var convertInfixToPostfixExpression = new ConvertInfixToPostfixExpression();

        var sut = new ConverterRunner(convertStringToExpression, convertInfixToPostfixExpression);

        var result = sut.RunConverters(stringExpression);
        Assert.Equal(correctAnswer.ToString(), result.ToString());
    }
}