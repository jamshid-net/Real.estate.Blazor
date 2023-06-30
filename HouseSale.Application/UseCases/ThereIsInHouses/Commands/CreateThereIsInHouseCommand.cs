using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities.BoolTypeEntities;
using MediatR;

namespace HouseSale.Application.UseCases.ThereIsInHouses.Commands;
public class CreateThereIsInHouseCommand : IRequest<Guid>
{
    public bool Ethernet { get; init; }
    public bool Phone { get; init; }
    public bool Pool { get; init; }
    public bool Garage { get; init; }
    public bool Canalization { get; init; }
    public bool GreenZone { get; init; }
    public bool Security { get; init; }
    public bool Cellar { get; init; }
    public bool Gym { get; init; }
}

public class CreateThereIsInHouseCommandHandler : IRequestHandler<CreateThereIsInHouseCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateThereIsInHouseCommandHandler(IApplicationDbContext context)
            => _context = context;
    public async Task<Guid> Handle(CreateThereIsInHouseCommand request, CancellationToken cancellationToken)
    {
        ThereIsInHouse thereIsInHouse = new ThereIsInHouse
        {
            Ethernet = request.Ethernet,
            Phone = request.Phone,
            Pool = request.Pool,
            Garage = request.Garage,
            Canalization = request.Canalization,
            GreenZone = request.GreenZone,
            Security = request.Security,
            Cellar = request.Cellar,
            Gym = request.Gym
        };

        await _context.ThereIsInHouses.AddAsync(thereIsInHouse, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return thereIsInHouse.ThereIsInHouseId;
    }
}
