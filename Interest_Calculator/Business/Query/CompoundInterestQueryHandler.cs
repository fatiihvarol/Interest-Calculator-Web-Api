using Interest_Calculator.Base.Helpers;
using Interest_Calculator.Base.Response;
using Interest_Calculator.Business.Cqrs;
using Interest_Calculator.Schema;
using MediatR;

namespace Interest_Calculator.Business.Query;
 
public class CompoundInterestQueryHandler :
    IRequestHandler<CalculateCompoundInterestQuery, ApiResponse<InterestResponse>>
{
    public Task<ApiResponse<InterestResponse>> Handle(CalculateCompoundInterestQuery request, CancellationToken cancellationToken)
    {
        if (request.Model.InterestFrequency == null)
        {
            return Task.FromResult(new ApiResponse<InterestResponse>("Bad Request"));
        }

        decimal numberOfCompoundingPeriods = GetNumberOfCompoundingPeriods.Get(request.Model.InterestFrequency);

        // Calculate compound interest with the correct formula
        decimal compoundInterest = request.Model.Principal * (decimal)Math.Pow(1 + (double)(request.Model.InterestRate / (100 * numberOfCompoundingPeriods)), (double)(request.Model.Maturity * numberOfCompoundingPeriods)) - request.Model.Principal;

        decimal totalBalance = request.Model.Principal + compoundInterest;

        var response = new InterestResponse
        {
            InterestIncome = compoundInterest,
            TotalBalance = totalBalance
        };

        return Task.FromResult(new ApiResponse<InterestResponse>(response));
    }
}