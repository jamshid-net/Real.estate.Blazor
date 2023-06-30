using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities.BoolTypeEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseSale.Application.UseCases.LocatedNearbies.Queries;
public record GetAllLocatedNeardyQuery : IRequest<List<LocatedNearby>>;
public class GetAllLocatedNeardyQueryHandler : IRequestHandler<GetAllLocatedNeardyQuery, List<LocatedNearby>>
{
    private readonly IApplicationDbContext _context;

    public GetAllLocatedNeardyQueryHandler(IApplicationDbContext context)
            => _context = context;
    public async Task<List<LocatedNearby>> Handle(GetAllLocatedNeardyQuery request, CancellationToken cancellationToken)
        => await _context.LocatedNearbies.AsNoTracking().ToListAsync(cancellationToken);
}
