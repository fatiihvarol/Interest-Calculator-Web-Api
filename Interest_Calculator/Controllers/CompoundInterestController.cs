using Interest_Calculator.Base.Helpers;
using Interest_Calculator.Base.Response;
using Interest_Calculator.Business.Cqrs;
using Interest_Calculator.Schema;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Interest_Calculator.Controllers
{
    // Bileşik faiz hesaplamalarını işleyen kontrolör sınıfı
    [Route("api/[controller]")]
    [ApiController]
    public class CompoundInterestController(ISender mediator)  : ControllerBase
    {
        // Bileşik faiz hesaplaması için gelen isteği işleyen eylem
        [HttpPost]
        public async Task<ApiResponse<InterestResponse>> Calculate([FromBody] InterestRequest request)
        {
            // CalculateCompoundInterestQuery sorgusunu oluştur
            var query = new CalculateCompoundInterestQuery(request);

            // Mediator aracılığıyla sorguyu gönder ve sonucu al
            var result = await mediator.Send(query);

            // Sonucu ApiResponse<InterestResponse> tipinde döndür
            return result;
        }
    }
}