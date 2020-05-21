using System;

namespace Calculator.Domain
{
    public interface ICalculatorService
    {
        CalculationResult Add(decimal left, decimal right);
        CalculationResult Subtract(decimal left, decimal right);
        CalculationResult Multiply(decimal left, decimal right);
        CalculationResult Divide(decimal left, decimal right);
    }

    public class CalculatorService : ICalculatorService
    {
        public CalculationResult Add(decimal left, decimal right)
        {
            try
            {
                var result = left + right;

                return CalculationResult.Successful(result);
            }
            catch (OverflowException)
            {
                return CalculationResult.Failed(CalculationResultReason.ArithmeticOverflow);
            }
        }

        public CalculationResult Subtract(decimal left, decimal right)
        {
            try
            {
                var result = left - right;

                return CalculationResult.Successful(result);
            }
            catch (OverflowException)
            {
                return CalculationResult.Failed(CalculationResultReason.ArithmeticOverflow);
            }
        }

        public CalculationResult Divide(decimal left, decimal right)
        {
            if (right == 0m) return CalculationResult.Failed(CalculationResultReason.DivideByZero);

            try
            {
                var result = left / right;

                return CalculationResult.Successful(result);
            }
            catch (OverflowException)
            {
                return CalculationResult.Failed(CalculationResultReason.ArithmeticOverflow);
            }
        }

        public CalculationResult Multiply(decimal left, decimal right)
        {
            try
            {
                var result = left * right;

                return CalculationResult.Successful(result);
            }
            catch (OverflowException)
            {
                return CalculationResult.Failed(CalculationResultReason.ArithmeticOverflow);
            }
        }
    }
}
