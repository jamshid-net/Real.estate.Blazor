using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities.BoolTypeEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSale.Application.UseCases.HomeSituations.Queries;
public class GetByIdHomeSituationQuery:IRequest<HomeSituation>
{
    public Guid HomeSituationId { get; set; }   
}
public class GetByIdHomeSituationQueryHandler : IRequestHandler<GetByIdHomeSituationQuery, HomeSituation>
{
    private readonly IApplicationDbContext _context;

    public GetByIdHomeSituationQueryHandler(IApplicationDbContext context)
           => _context = context;
    
    

    public async Task<HomeSituation> Handle(GetByIdHomeSituationQuery request, CancellationToken cancellationToken)
    {
        var foundHomeSituation = await _context.HomeSituations.FindAsync(new object[] { request.HomeSituationId }, cancellationToken);
        if (foundHomeSituation is null)
            throw new NotFoundException(nameof(HomeSituation), request.HomeSituationId);

        return foundHomeSituation;
    }
}
