using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Calculator.Domain.Test
{
    public class CalculatorServiceTest
    {
        private static readonly Dictionary<OperationKind, Func<ICalculatorService, decimal, decimal, CalculationResult>> OperationMap = new Dictionary<OperationKind, Func<ICalculatorService, decimal, decimal, CalculationResult>>
        {
            { OperationKind.Add, (calculator, left, right) => calculator.Add(left, right) },
            { OperationKind.Subtract, (calculator, left, right) => calculator.Subtract(left, right) },
            { OperationKind.Multiple, (calculator, left, right) => calculator.Multiply(left, right) },
            { OperationKind.Divide, (calculator, left, right) => calculator.Divide(left, right) },
        };

        [Theory]
        [InlineData(OperationKind.Add, 13, 17, "30")]
        [InlineData(OperationKind.Subtract, 13, 17, "-4")]
        [InlineData(OperationKind.Multiple, 13, 17, "221")]
        [InlineData(OperationKind.Divide, 13, 17, "0.7647058823529411764705882353")]
        public void Can_Perform_Arithmetics(OperationKind op, decimal left, decimal right, string expected)
        {
            var sut = new CalculatorService();
            var actual = OperationMap[op](sut, left, right);

            actual.Success.Should().BeTrue();
            actual.Result.ToString().Should().Be(expected);
        }

        [Theory]
        [InlineData(OperationKind.Add, true, 2)]
        [InlineData(OperationKind.Subtract, false, 2)]
        [InlineData(OperationKind.Multiple, true, 2)]
        [InlineData(OperationKind.Divide, true, 0.2)]
        public void Should_Return_ArithmeticOverflow_Error(OperationKind op, bool positiveNumber, decimal right)
        {
            var sut = new CalculatorService();
            var expected = new CalculationResult { Success = false, Reason = CalculationResultReason.ArithmeticOverflow };
            var left = positiveNumber ? decimal.MaxValue : decimal.MinValue;
            var actual = OperationMap[op](sut, left, right);

            actual.Success.Should().BeFalse();
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_Return_DivideByZero_Error()
        {
            var sut = new CalculatorService();
            var expected = new CalculationResult { Success = false, Reason = CalculationResultReason.DivideByZero };

            var actual = sut.Divide(22, 0);

            actual.Should().BeEquivalentTo(expected);
        }

        public enum OperationKind
        {
            Add,
            Subtract,
            Multiple,
            Divide
        }
    }
}
