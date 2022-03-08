using System.Collections.Generic;
using Maths.Api.Enums;
using Maths.Api.Services.Evaluators;
using Maths.Api.Services.Expressions;
using Maths.Api.Services.Tokens;
using Xunit;

namespace Maths.Api.Tests;

public class EvaluatorRunnerShould
{
    [Fact]
    public void CorrectlyEvaluateThreePlusFourTimesTwoMinusFiveDivideByThreeFromStringInput()
    {
        var stringExpression = new Expression(new List<IToken>()
        {
            new StringToken("3 + 4*2 - 5/3")
        }, ExpressionType.InfixString);

        const double correctAnswer = 3 + 4 * 2 - 5.0d / 3;
        
        var evaluators = new List<IEvaluator>()
        {
            new EvaluateStringExpression(),
            new EvaluateInfixExpression(),
            new EvaluatePostfixExpression()
        };

        var sut = new EvaluatorRunner(evaluators);

        var result = sut.Run(stringExpression);
        Assert.Equal(correctAnswer, double.Parse(result.ToString()));
    }
}