using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseSale.Application.UseCases.HouseImages.Queries;
public record GetAllHouseImageQuery : IRequest<List<HouseImage>>;
public class GetAllHouseImageQueryHandler : IRequestHandler<GetAllHouseImageQuery, List<HouseImage>>
{
    private readonly IApplicationDbContext _context;

    public GetAllHouseImageQueryHandler(IApplicationDbContext context)
        => _context = context;
    public async Task<List<HouseImage>> Handle(GetAllHouseImageQuery request, CancellationToken cancellationToken)
        => await _context.HouseImages.AsNoTracking().ToListAsync(cancellationToken);
}
