using Interest_Calculator.Base.Helpers;
using Interest_Calculator.Base.Response;
using Interest_Calculator.Business.Cqrs;
using Interest_Calculator.Schema;
using MediatR;

namespace Interest_Calculator.Business.Query
{
    // CalculateBasicInterestQuery tipinde bir isteği işleyen sınıf
    public class BasicInterestQueryHandler :
        IRequestHandler<CalculateBasicInterestQuery, ApiResponse<InterestResponse>>
    {
        // CalculateBasicInterestQuery isteğini işleyen metot
        public Task<ApiResponse<InterestResponse>> Handle(CalculateBasicInterestQuery request, CancellationToken cancellationToken)
        {
            //Gelen istekteki InterestFrequency bad request dön
            if (request.Model.InterestFrequency==null)
                return Task.FromResult(new ApiResponse<InterestResponse>("Bad Request"));
 
            // Gelen istek üzerinden faiz geliri ve toplam bakiyeyi hesapla
            decimal income = request.Model.Principal * request.Model.InterestRate * (request.Model.Maturity * GetNumberOfDays.GetDays(request.Model.InterestFrequency));
            decimal balance = request.Model.Principal + income;

            // Hesaplanan değerleri kullanarak InterestResponse nesnesi oluştur
            var response = new InterestResponse
            {
                InterestIncome = income,
                TotalBalance = balance
            };

            // ApiResponse<InterestResponse> tipinde bir nesneyi Task<ApiResponse<InterestResponse>>'ye dönüştür
            return Task.FromResult(new ApiResponse<InterestResponse>(response));
        }
    }
}