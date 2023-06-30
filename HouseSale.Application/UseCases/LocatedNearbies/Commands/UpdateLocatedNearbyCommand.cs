using HouseSale.Application.Commons.Interfaces;

using HouseSale.Domain.Entities.BoolTypeEntities;

using MediatR;

namespace HouseSale.Application.UseCases.LocatedNearbies.Commands;
public class UpdateLocatedNearbyCommand : IRequest
{
    public Guid LocatedNearbyId { get; set; }
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

public class UpdateLocatedNearbyCommandHandler : IRequestHandler<UpdateLocatedNearbyCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateLocatedNearbyCommandHandler(IApplicationDbContext context)
            => _context = context;
    public async Task Handle(UpdateLocatedNearbyCommand request, CancellationToken cancellationToken)
    {
        var locatedNearby = await _context.LocatedNearbies.FindAsync(new object[] { request.LocatedNearbyId }, cancellationToken);
        if (locatedNearby is null)

            throw new NotFoundException(nameof(LocatedNearby), request.LocatedNearbyId);


        locatedNearby.Hospital = request.Hospital;
        locatedNearby.Playground = request.Playground;
        locatedNearby.Kindergarten = request.Kindergarten;
        locatedNearby.Stations = request.Stations;
        locatedNearby.Park = request.Park;
        locatedNearby.EntertainmentInstitutions = request.EntertainmentInstitutions;
        locatedNearby.Restaurants = request.Restaurants;
        locatedNearby.Residence = request.Residence;
        locatedNearby.Supermarkets = request.Supermarkets;
        locatedNearby.School = request.School;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
