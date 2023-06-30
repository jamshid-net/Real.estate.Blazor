using HouseSale.Application.Commons.Interfaces;

using HouseSale.Domain.Entities.BoolTypeEntities;

using MediatR;

namespace HouseSale.Application.UseCases.LocatedNearbies.Commands;
public class DeleteLocatedNearbyCommand : IRequest
{
    public Guid LocatedNearbyId { get; set; }
}

public class DeleteLocatedNearbyCommandHandler : IRequestHandler<DeleteLocatedNearbyCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteLocatedNearbyCommandHandler(IApplicationDbContext context)
            => _context = context;
    public async Task Handle(DeleteLocatedNearbyCommand request, CancellationToken cancellationToken)
    {
        var locatedNearby = await _context.LocatedNearbies.FindAsync(new object[] { request.LocatedNearbyId }, cancellationToken);
        if (locatedNearby is null)

            throw new NotFoundException(nameof(LocatedNearby), request.LocatedNearbyId);


        _context.LocatedNearbies.Remove(locatedNearby);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
