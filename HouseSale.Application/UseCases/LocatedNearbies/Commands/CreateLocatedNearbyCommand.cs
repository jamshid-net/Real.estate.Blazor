using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities.BoolTypeEntities;
using MediatR;

namespace HouseSale.Application.UseCases.LocatedNearbies.Commands;
public class CreateLocatedNearbyCommand : IRequest<Guid>
{
    public bool Hospital { get; init; }
    public bool Playground { get; init; }
    public bool Kindergarten { get; init; }
    public bool Stations { get; init; }
    public bool Park { get; init; }
    public bool EntertainmentInstitutions { get; init; }
    public bool Restaurants { get; init; }
    public bool Residence { get; init; }
    public bool Supermarkets { get; init; }
    public bool School { get; init; }
}

public class CreateLocatedNearbyCommandHandler : IRequestHandler<CreateLocatedNearbyCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateLocatedNearbyCommandHandler(IApplicationDbContext context)
            => _context = context;
    public async Task<Guid> Handle(CreateLocatedNearbyCommand request, CancellationToken cancellationToken)
    {
        LocatedNearby locatedNearby = new LocatedNearby
        {
            Hospital = request.Hospital,
            Playground = request.Playground,
            Kindergarten = request.Kindergarten,
            Stations = request.Stations,
            Park = request.Park,
            EntertainmentInstitutions = request.EntertainmentInstitutions,
            Restaurants = request.Restaurants,
            Residence = request.Residence,
            Supermarkets = request.Supermarkets,
            School = request.School
        };

        await _context.LocatedNearbies.AddAsync(locatedNearby, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return locatedNearby.LocatedNearbyId;
    }
}
