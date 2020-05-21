using Calculator.Domain;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Calculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService ?? throw new ArgumentNullException(nameof(calculatorService));
        }

        // GET add
        [HttpGet("add")]
        public ActionResult Add([FromQuery] decimal left, [FromQuery] decimal right)
        {
            return PrepareResult(_calculatorService.Add(left, right));
        }

        // GET subtract
        [HttpGet("subtract")]
        public ActionResult Subtract([FromQuery] decimal left, [FromQuery] decimal right)
        {
            return PrepareResult(_calculatorService.Subtract(left, right));
        }

        // GET multiply
        [HttpGet("multiply")]
        public ActionResult Multiply([FromQuery] decimal left, [FromQuery] decimal right)
        {
            return PrepareResult(_calculatorService.Multiply(left, right));
        }

        // GET divide
        [HttpGet("divide")]
        public ActionResult Divide([FromQuery] decimal left, [FromQuery] decimal right)
        {
            return PrepareResult(_calculatorService.Divide(left, right));
        }

        private ActionResult PrepareResult(CalculationResult result)
        {
            if (result.Success) return Ok(result.Result);

            return BadRequest(result.Reason);
        }
    }
}
