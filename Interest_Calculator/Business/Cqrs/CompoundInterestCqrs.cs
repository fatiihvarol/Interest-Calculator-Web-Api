using Interest_Calculator.Base.Response;
using Interest_Calculator.Entity;
using Interest_Calculator.Schema;
using MediatR;

namespace Interest_Calculator.Business.Cqrs;

public record CalculateCompoundInterestQuery(Interest Model ):IRequest <ApiResponse<InterestResponse>>;
