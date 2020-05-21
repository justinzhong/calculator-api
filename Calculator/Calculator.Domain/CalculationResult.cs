namespace Calculator.Domain
{
    public class CalculationResult
    {
        public bool Success { get; set; }

        public decimal? Result { get; set; }

        public CalculationResultReason Reason { get; set; }

        public static CalculationResult Successful(decimal result) => new CalculationResult { Success = true, Result = result };

        public static CalculationResult Failed(CalculationResultReason reason) => new CalculationResult { Success = false, Reason = reason };
    }
}
