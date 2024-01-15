using Interest_Calculator.Base.Helpers;
using Interest_Calculator.Base.Response;
using Interest_Calculator.Business.Cqrs;
using Interest_Calculator.Schema;
using MediatR;

namespace Interest_Calculator.Business.Query;
public class CompoundInterestQueryHandler : IRequestHandler<CalculateCompoundInterestQuery, ApiResponse<InterestResponse>>
{
    public Task<ApiResponse<InterestResponse>> Handle(CalculateCompoundInterestQuery request, CancellationToken cancellationToken)
    {
        if (request.Model.InterestFrequency == null)
            return Task.FromResult(new ApiResponse<InterestResponse>("Bad Request"));
        

        decimal compoundInterest = request.Model.Principal * (decimal)Math.Pow(1 + (double)(request.Model.InterestRate / (100 * GetNumberOfCompoundingPeriods.Get(request.Model.InterestFrequency))), (double)(request.Model.Maturity * GetNumberOfCompoundingPeriods.Get(request.Model.InterestFrequency))) - request.Model.Principal;

        decimal totalBalance = request.Model.Principal + compoundInterest;

        var response = new InterestResponse
        {
            InterestIncome = Math.Round(compoundInterest, 2, MidpointRounding.AwayFromZero),
            TotalBalance = Math.Round(totalBalance, 2, MidpointRounding.AwayFromZero)
        };

        // Return ApiResponse<InterestResponse>
        return Task.FromResult(new ApiResponse<InterestResponse>(response));
    }
}
