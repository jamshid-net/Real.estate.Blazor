using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities.BoolTypeEntities;
using MediatR;

namespace HouseSale.Application.UseCases.ThereIsInHouses.Queries;
public class GetByIdThereIsInHouseQuery : IRequest<ThereIsInHouse>
{
    public Guid ThereIsInHouseId { get; init; }
}

public class GetByIdThereIsInHouseQueryHandler : IRequestHandler<GetByIdThereIsInHouseQuery, ThereIsInHouse>
{
    private readonly IApplicationDbContext _context;

    public GetByIdThereIsInHouseQueryHandler(IApplicationDbContext context)
            => _context = context;
    public async Task<ThereIsInHouse> Handle(GetByIdThereIsInHouseQuery request, CancellationToken cancellationToken)
    {
        var thereIsInHouse = await _context.ThereIsInHouses.FindAsync(new object[] { request.ThereIsInHouseId }, cancellationToken);
        if (thereIsInHouse is null)
            throw new NotFoundException();

        return thereIsInHouse;
    }
}
