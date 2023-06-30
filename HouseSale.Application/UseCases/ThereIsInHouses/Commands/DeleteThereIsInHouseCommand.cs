using HouseSale.Application.Commons.Interfaces;
using MediatR;

namespace HouseSale.Application.UseCases.ThereIsInHouses.Commands;
public class DeleteThereIsInHouseCommand : IRequest
{
    public Guid ThereIsInHouseId { get; init; }
}

public class DeleteThereIsInHouseCommandHandler : IRequestHandler<DeleteThereIsInHouseCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteThereIsInHouseCommandHandler(IApplicationDbContext context)
            => _context = context;
    public async Task Handle(DeleteThereIsInHouseCommand request, CancellationToken cancellationToken)
    {
        var thereIsInHouse = await _context.ThereIsInHouses.FindAsync(new object[] { request.ThereIsInHouseId }, cancellationToken);
        if (thereIsInHouse is null)
            throw new NotFoundException();
        _context.ThereIsInHouses.Remove(thereIsInHouse);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
