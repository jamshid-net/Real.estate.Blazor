using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities.BoolTypeEntities;
using MediatR;

namespace HouseSale.Application.UseCases.LocatedNearbies.Commands;
public class CreateLocatedNearbyCommand : IRequest<Guid>
{
    public bool Hospital { get; set; } = false;
    public bool Playground { get; set;}=false;
    public bool Kindergarten { get; set;}=false;
    public bool Stations { get; set;}=false;
    public bool Park { get; set;}=false;
    public bool EntertainmentInstitutions { get; set;}=false;
    public bool Restaurants { get; set;}=false;
    public bool Residence { get; set;}=false;
    public bool Supermarkets { get; set;}=false;
    public bool School { get; set;}=false;
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
