using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseSale.Application.UseCases.Houses.Queries;
public record GetAllHouseQuery:IRequest<List<House>>;
public class GetAllHouseQueryHandler : IRequestHandler<GetAllHouseQuery, List<House>>
{
    private readonly IApplicationDbContext _context;
    public GetAllHouseQueryHandler(IApplicationDbContext context)
        => _context = context;
    public async Task<List<House>> Handle(GetAllHouseQuery request, CancellationToken cancellationToken)
        => await _context.Houses.AsNoTracking().ToListAsync(cancellationToken);
}
