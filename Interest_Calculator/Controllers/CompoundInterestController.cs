using Interest_Calculator.Base.Helpers;
using Interest_Calculator.Base.Response;
using Interest_Calculator.Schema;

namespace Interest_Calculator.Controllers;


using Microsoft.AspNetCore.Mvc;
using System;


    [Route("api/[controller]")]
    [ApiController]
    public class CompoundInterestController : ControllerBase
    {
      

        [HttpPost]
        public ApiResponse<InterestResponse> Calculate([FromBody] InterestRequest request)
        {
            decimal numberOfCompoundingPeriods = GetNumberOfCompoundingPeriods.Get(request.InterestFrequency);
    
            // Calculate compound interest with the correct formula
            decimal compoundInterest = request.Principal * (decimal)Math.Pow(1 + (double)(request.InterestRate / (100 * numberOfCompoundingPeriods)), (double)(request.Maturity * numberOfCompoundingPeriods)) - request.Principal;

            decimal totalBalance = request.Principal + compoundInterest;

            var response = new InterestResponse
            {
                InterestIncome =compoundInterest,
                TotalBalance = totalBalance
            };

            return new ApiResponse<InterestResponse>(response);
        }
    

    }
