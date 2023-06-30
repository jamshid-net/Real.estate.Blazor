using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities;
using MediatR;

namespace HouseSale.Application.UseCases.HouseImages.Queries;
public class GetByIdHouseImageQuery : IRequest<HouseImage>
{
    public Guid HouseImageId { get; init; }
}

public class GetByIdHouseImageQueryHandler : IRequestHandler<GetByIdHouseImageQuery, HouseImage>
{
    private readonly IApplicationDbContext _context;

    public GetByIdHouseImageQueryHandler(IApplicationDbContext context)
        => _context = context;
    public async Task<HouseImage> Handle(GetByIdHouseImageQuery request, CancellationToken cancellationToken)
    {
        var houseImage = await _context.HouseImages.FindAsync(new object[] { request.HouseImageId }, cancellationToken);
        if (houseImage is null)
            throw new NotFoundException(nameof(HouseImage), request.HouseImageId);
        
        return houseImage;
    }

}
