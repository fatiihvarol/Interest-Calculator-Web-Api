using Interest_Calculator.Base.Helpers;
using Interest_Calculator.Base.Response;
using Interest_Calculator.Business.Cqrs;
using Interest_Calculator.Schema;
using MediatR;

namespace Interest_Calculator.Business.Query
{
    // CalculateCompoundInterestQuery tipinde bir isteği işleyen sınıf
    public class CompoundInterestQueryHandler :
        IRequestHandler<CalculateCompoundInterestQuery, ApiResponse<InterestResponse>>
    {
        // CalculateCompoundInterestQuery isteğini işleyen metot
        public Task<ApiResponse<InterestResponse>> Handle(CalculateCompoundInterestQuery request, CancellationToken cancellationToken)
        {
            // Eğer InterestFrequency null ise, hatalı istek durumuyla ApiResponse dön
            if (request.Model.InterestFrequency == null)
            {
                return Task.FromResult(new ApiResponse<InterestResponse>("Bad Request"));
            }

            // Faiz frekansına göre bileşikleme periyodunu hesapla
            decimal numberOfCompoundingPeriods = GetNumberOfCompoundingPeriods.Get(request.Model.InterestFrequency);

            // Doğru formülle bileşik faiz hesapla
            decimal compoundInterest = request.Model.Principal * (decimal)Math.Pow(1 + (double)(request.Model.InterestRate / (100 * numberOfCompoundingPeriods)), (double)(request.Model.Maturity * numberOfCompoundingPeriods)) - request.Model.Principal;

            // Toplam bakiyeyi hesapla
            decimal totalBalance = request.Model.Principal + compoundInterest;

            // Hesaplanan değerleri kullanarak InterestResponse nesnesi oluştur
            var response = new InterestResponse
            {
                InterestIncome = compoundInterest,
                TotalBalance = totalBalance
            };

            // ApiResponse<InterestResponse> tipinde bir nesneyi Task<ApiResponse<InterestResponse>>'ye dönüştür
            return Task.FromResult(new ApiResponse<InterestResponse>(response));
        }
    }
}