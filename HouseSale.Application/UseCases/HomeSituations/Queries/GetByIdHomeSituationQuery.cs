using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities;
using MediatR;

namespace HouseSale.Application.UseCases.HomeSituations.Queries;
public class GetByIdHomeSituationQuery:IRequest<CategoryHomeSituation>
{
    public Guid HomeSituationId { get; set; }   
}
public class GetByIdHomeSituationQueryHandler : IRequestHandler<GetByIdHomeSituationQuery, CategoryHomeSituation>
{
    private readonly IApplicationDbContext _context;

    public GetByIdHomeSituationQueryHandler(IApplicationDbContext context)
           => _context = context;
    
    

    public async Task<CategoryHomeSituation> Handle(GetByIdHomeSituationQuery request, CancellationToken cancellationToken)
    {
        var foundHomeSituation = await _context.HomeSituations.FindAsync(new object[] { request.HomeSituationId }, cancellationToken);
        if (foundHomeSituation is null)
            throw new NotFoundException(nameof(CategoryHomeSituation), request.HomeSituationId);

        return foundHomeSituation;
    }
}
