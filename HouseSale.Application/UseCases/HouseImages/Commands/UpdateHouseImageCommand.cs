using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities;
using MediatR;

namespace HouseSale.Application.UseCases.HouseImages.Commands;
public class UpdateHouseImageCommand : IRequest
{
    public Guid HouseImageId { get; init; }
    public string ImagePath { get; init; }
    public Guid HouseId { get; init; }
}

public class UpdateHouseImageCommandHandler : IRequestHandler<UpdateHouseImageCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateHouseImageCommandHandler(IApplicationDbContext context)
        => _context = context;
    public async Task Handle(UpdateHouseImageCommand request, CancellationToken cancellationToken)
    {
        var houseImage = await _context.HouseImages.FindAsync(new object[] { request.HouseImageId }, cancellationToken);
        if (houseImage is null)
            throw new NotFoundException(nameof(HouseImage), request.HouseImageId);

        houseImage.ImagePath = request.ImagePath;
        houseImage.HouseId = request.HouseId;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
