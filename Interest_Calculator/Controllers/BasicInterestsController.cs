using Interest_Calculator.Base.Helpers;
using Interest_Calculator.Base.Response;
using Interest_Calculator.Schema;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Interest_Calculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicInterestsController : ControllerBase
    {
        [HttpPost]
        public ApiResponse<InterestResponse> Calculate([FromBody] InterestRequest request)
        {
            decimal income = request.Principal * request.InterestRate * (request.Maturity * GetNumberOfDays.GetDays(request.InterestFrequency));
            decimal balance = request.Principal + income;

            var response = new InterestResponse
            {
                InterestIncome = income,
                TotalBalance = balance
            };

            return new ApiResponse<InterestResponse>(response);
        }
    }
}