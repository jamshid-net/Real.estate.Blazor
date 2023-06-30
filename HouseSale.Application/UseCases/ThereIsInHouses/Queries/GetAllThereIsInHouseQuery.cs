using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities.BoolTypeEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseSale.Application.UseCases.ThereIsInHouses.Queries;
public record GetAllThereIsInHouseQuery : IRequest<List<ThereIsInHouse>>;
public class GetAllThereIsInHouseQueryHandler : IRequestHandler<GetAllThereIsInHouseQuery, List<ThereIsInHouse>>
{
    private readonly IApplicationDbContext _context;

    public GetAllThereIsInHouseQueryHandler(IApplicationDbContext context)
            => _context = context;
    public async Task<List<ThereIsInHouse>> Handle(GetAllThereIsInHouseQuery request, CancellationToken cancellationToken)
        => await _context.ThereIsInHouses.AsNoTracking().ToListAsync(cancellationToken);
}
