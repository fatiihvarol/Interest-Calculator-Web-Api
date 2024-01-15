using Interest_Calculator.Schema;

namespace Interest_Calculator.Controllers;


using Microsoft.AspNetCore.Mvc;
using System;


    [Route("api/[controller]")]
    [ApiController]
    public class CompoundInterestController : ControllerBase
    {
        private decimal GetNumberOfCompoundingPeriods(string interestFrequency)
        {
            switch (interestFrequency.ToLower())
            {
                case "gün":
                    return 365m;
                case "ay":
                    return 12m;
                case "yıl":
                    return 1m;
                default:
                    return 1m;
            }
        }

        [HttpPost]
        public IActionResult Calculate([FromBody] InterestRequest request)
        {
            decimal numberOfCompoundingPeriods = GetNumberOfCompoundingPeriods(request.InterestFrequency);
    
            // Calculate compound interest with the correct formula
            decimal compoundInterest = request.Principal * (decimal)Math.Pow(1 + (double)(request.InterestRate / (100 * numberOfCompoundingPeriods)), (double)(request.Maturity * numberOfCompoundingPeriods)) - request.Principal;

            decimal totalBalance = request.Principal + compoundInterest;

            var response = new InterestResponse
            {
                InterestIncome =compoundInterest,
                TotalBalance = totalBalance
            };

            return Ok(response);
        }
    

    }
