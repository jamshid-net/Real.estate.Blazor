using HouseSale.Application.Commons.Interfaces;

using HouseSale.Domain.Entities.BoolTypeEntities;

using MediatR;

namespace HouseSale.Application.UseCases.ThereIsInHouses.Commands;
public class UpdateThereIsInHouseCommand : IRequest
{
    public Guid ThereIsInHouseId { get; init; }
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

public class UpdateThereIsInHouseCommandHandler : IRequestHandler<UpdateThereIsInHouseCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateThereIsInHouseCommandHandler(IApplicationDbContext context)
            => _context = context;
    public async Task Handle(UpdateThereIsInHouseCommand request, CancellationToken cancellationToken)
    {
        var thereIsInHouse = await _context.ThereIsInHouses.FindAsync(new object[] { request.ThereIsInHouseId }, cancellationToken);
        if (thereIsInHouse is null)

            throw new NotFoundException(nameof(ThereIsInHouse), request.ThereIsInHouseId);


        thereIsInHouse.Ethernet = request.Ethernet;
        thereIsInHouse.Phone = request.Phone;
        thereIsInHouse.Pool = request.Pool;
        thereIsInHouse.Garage = request.Garage;
        thereIsInHouse.Canalization = request.Canalization;
        thereIsInHouse.GreenZone = request.GreenZone;
        thereIsInHouse.Security = request.Security;
        thereIsInHouse.Cellar = request.Cellar;
        thereIsInHouse.Gym = request.Gym;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
