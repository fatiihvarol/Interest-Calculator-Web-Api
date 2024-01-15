using Interest_Calculator.Base.Helpers;
using Interest_Calculator.Base.Response;
using Interest_Calculator.Business.Cqrs;
using Interest_Calculator.Schema;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Interest_Calculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicInterestsController(ISender mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ApiResponse<InterestResponse>>> Calculate([FromBody] InterestRequest request)
        {
            var query = new CalculateBasicInterestQuery(request);
            var result = await mediator.Send(query);
            return result;
        }
        
    }
}