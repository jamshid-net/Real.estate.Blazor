using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities;
using MediatR;

namespace HouseSale.Application.UseCases.HouseImages.Commands;
public class DeleteHouseImageCommand : IRequest
{
    public Guid HouseImageId { get; init; }
}

public class DeleteHouseImageCommandHandler : IRequestHandler<DeleteHouseImageCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteHouseImageCommandHandler(IApplicationDbContext context)
        => _context = context;
    public async Task Handle(DeleteHouseImageCommand request, CancellationToken cancellationToken)
    {
        var houseImage = await _context.HouseImages.FindAsync(new object[] { request.HouseImageId }, cancellationToken);
        if (houseImage is null)
            throw new NotFoundException(nameof(HouseImage), request.HouseImageId);

        _context.HouseImages.Remove(houseImage);
        await _context.SaveChangesAsync(cancellationToken);
    }

}
