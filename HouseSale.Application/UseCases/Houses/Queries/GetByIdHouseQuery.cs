using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities;
using MediatR;

namespace HouseSale.Application.UseCases.Houses.Queries;
public class GetByIdHouseQuery:IRequest<House>
{
    public Guid HouseId { get; init; }
}
public class GetByIdHouseQueryHandler : IRequestHandler<GetByIdHouseQuery, House>
{
    private readonly IApplicationDbContext _context;
    public GetByIdHouseQueryHandler(IApplicationDbContext context)
        => _context = context;
    public async Task<House> Handle(GetByIdHouseQuery request, CancellationToken cancellationToken)
    {
        var foundHouse =await _context.Houses.FindAsync(new object[] { request.HouseId },cancellationToken);
        if(foundHouse is null)  
            throw new NotFoundException(nameof(House),request.HouseId);

        return foundHouse;
    }
}