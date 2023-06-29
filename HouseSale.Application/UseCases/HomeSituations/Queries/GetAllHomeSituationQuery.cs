using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities.BoolTypeEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseSale.Application.UseCases.HomeSituations.Queries;
public record GetAllHomeSituationQuery:IRequest<List<HomeSituation>>;
public class GetAllHomeSituationQueryHandler : IRequestHandler<GetAllHomeSituationQuery, List<HomeSituation>>
{
    private readonly IApplicationDbContext _context;
    public GetAllHomeSituationQueryHandler(IApplicationDbContext context)
            => _context = context;
    public async Task<List<HomeSituation>> Handle(GetAllHomeSituationQuery request, CancellationToken cancellationToken)
            => await _context.HomeSituations.AsNoTracking().ToListAsync(cancellationToken);
}

