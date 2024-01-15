using Interest_Calculator.Base.Helpers;
using Interest_Calculator.Base.Response;
using Interest_Calculator.Business.Cqrs;
using Interest_Calculator.Schema;
using MediatR;

namespace Interest_Calculator.Controllers;


using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class CompoundInterestController(ISender mediator)  : ControllerBase
    {
        [HttpPost]
        public async Task<ApiResponse<InterestResponse>> Calculate([FromBody] InterestRequest request)
        {
            var query = new CalculateCompoundInterestQuery(request);
            var result = await mediator.Send(query);
            return result;
        }
    

    }
