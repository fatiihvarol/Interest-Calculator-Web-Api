using Interest_Calculator.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Interest_Calculator.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InterestsController : ControllerBase
{
    [HttpPost("simple-interest-calculation")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult SimpleInterestCalculation([FromBody] Interest model)
    {
        if (!ModelState.IsValid||model.InterestFrequency==null)
        {
            return BadRequest("Geçersiz giriş parametreleri");
        }

        int interestFrequencyMultiplier = GetInterestFrequencyMultiplier(model.InterestFrequency);

        decimal simpleInterest = model.Principal * model.InterestRate * model.Maturity * interestFrequencyMultiplier ;
        decimal totalAmount = model.Principal + simpleInterest;

        var response = new
        {
            SimpleInterest = simpleInterest,
            TotalAmount = totalAmount
        };

        return Ok(response);
    }

    [HttpPost("compound-interest-calculation")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CompoundInterestCalculation([FromBody] Interest model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Geçersiz giriş parametreleri");
        }

        int compoundFrequency = model.InterestFrequency == "monthly" ? 12 : 1; // Aylık faiz ödemesi durumu
        decimal compoundInterestRate = model.InterestRate / compoundFrequency;
        int totalCompounds = model.Maturity * compoundFrequency;

        decimal compoundInterest = model.Principal * (decimal)Math.Pow(1 + (double)compoundInterestRate, totalCompounds) - model.Principal;
        decimal totalAmount = model.Principal + compoundInterest;

        var response = new
        {
            CompoundInterest = compoundInterest,
            TotalAmount = totalAmount
        };

        return Ok(response);
    }
    private int GetInterestFrequencyMultiplier(string interestFrequency)
    {
        switch (interestFrequency?.ToLower())
        {
            case "day":
                return 365; // Günde bir faiz ödemesi
            case "month":
                return 12; // Aylık faiz ödemesi
            case "year":
                return 1; // Yılda bir faiz ödemesi
            default:
                return 1; // Varsayılan olarak yılda bir faiz ödemesi
        }
    }
}