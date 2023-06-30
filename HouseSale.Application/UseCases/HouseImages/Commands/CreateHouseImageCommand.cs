using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities;
using MediatR;

namespace HouseSale.Application.UseCases.HouseImages.Commands;
public class CreateHouseImageCommand : IRequest<Guid>
{
    public string ImagePath { get; init; }
    public Guid HouseId { get; init; }
}

public class CreateHouseImageCommandHandler : IRequestHandler<CreateHouseImageCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateHouseImageCommandHandler(IApplicationDbContext context)
        => _context = context;
    public async Task<Guid> Handle(CreateHouseImageCommand request, CancellationToken cancellationToken)
    {
        HouseImage houseImage = new HouseImage
        {
            ImagePath = request.ImagePath,
            HouseId = request.HouseId
        };
        await _context.HouseImages.AddAsync(houseImage, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return houseImage.HouseImageId;
    }

}
