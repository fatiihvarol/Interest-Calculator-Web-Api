using Interest_Calculator.Base.Helpers;
using Interest_Calculator.Base.Response;
using Interest_Calculator.Business.Cqrs;
using Interest_Calculator.Schema;
using MediatR;

namespace Interest_Calculator.Business.Query;

public class BasicInterestQueryHandler :
    IRequestHandler<CalculateBasicInterestQuery, ApiResponse<InterestResponse>>
{
    public  Task<ApiResponse<InterestResponse>> Handle(CalculateBasicInterestQuery request, CancellationToken cancellationToken)
    {
        decimal income = request.Model.Principal * request.Model.InterestRate * (request.Model.Maturity * GetNumberOfDays.GetDays(request.Model.InterestFrequency));
        decimal balance = request.Model.Principal + income;

        var response = new InterestResponse
        {
            InterestIncome = income,
            TotalBalance = balance
        };

        // ApiResponse<InterestResponse> tipinde bir nesneyi Task<ApiResponse<InterestResponse>>'ye dönüştür
        return Task.FromResult(new ApiResponse<InterestResponse>(response));
    }
}
