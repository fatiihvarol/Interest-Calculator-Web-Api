using Interest_Calculator.Base.Helpers;
using Interest_Calculator.Base.Response;
using Interest_Calculator.Business.Cqrs;
using Interest_Calculator.Schema;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Interest_Calculator.Controllers
{
    // Temel faiz hesaplamalarını işleyen kontrolör sınıfı
    [Route("api/[controller]")]
    [ApiController]
    public class BasicInterestsController(ISender mediator) : ControllerBase
    {
        // Faiz hesaplaması için gelen isteği işleyen eylem
        [HttpPost]
        public async Task<ActionResult<ApiResponse<InterestResponse>>> Calculate([FromBody] InterestRequest request)
        {
            // CalculateBasicInterestQuery sorgusunu oluştur
            var query = new CalculateBasicInterestQuery(request);

            // Mediator aracılığıyla sorguyu gönder ve sonucu al
            var result = await mediator.Send(query);

            // Sonucu ActionResult tipinde döndür
            return result;
        }
    }
}