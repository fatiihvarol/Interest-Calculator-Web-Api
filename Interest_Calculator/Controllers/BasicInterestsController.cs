using Interest_Calculator.Base;
using Interest_Calculator.Entity;
using Interest_Calculator.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Interest_Calculator.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasicInterestsController : ControllerBase
{
    [HttpPost]
    public IActionResult Calculate([FromBody] InterestRequest request)
    {
        decimal income = request.Principal * request.InterestRate * (request.Maturity * GetNumberOfDays.GetDays(request.InterestFrequency));
        decimal balance = request.Principal + income;

        var response = new InterestResponse
        {
            InterestIncome = income,
            TotalBalance = balance
        };

        return Ok(response);
    }


    

    
}