using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseSale.Application.UseCases.HomeSituations.Queries;
public record GetAllHomeSituationQuery:IRequest<List<CategoryHomeSituation>>;
public class GetAllHomeSituationQueryHandler : IRequestHandler<GetAllHomeSituationQuery, List<CategoryHomeSituation>>
{
    private readonly IApplicationDbContext _context;
    public GetAllHomeSituationQueryHandler(IApplicationDbContext context)
            => _context = context;
    public async Task<List<CategoryHomeSituation>> Handle(GetAllHomeSituationQuery request, CancellationToken cancellationToken)
            => await _context.HomeSituations.AsNoTracking().ToListAsync(cancellationToken);
}

