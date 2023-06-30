using HouseSale.Application.Commons.Interfaces;
using HouseSale.Application.UseCases.Addresses.Commands;
using HouseSale.Application.UseCases.HomeSituations.Commands;
using HouseSale.Application.UseCases.LocatedNearbies.Commands;
using HouseSale.Application.UseCases.ThereIsInHouses.Commands;
using HouseSale.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace HouseSale.Application.UseCases.Houses.Commands;
public class CreateHouseCommand:IRequest
{
    public string Description { get; init; }

    public decimal Price { get; init; }

    public float Area { get; init; }

    public int CountOfRoom { get; init; }

    public IFormFile MainImage { get; init; }
    public List<IFormFile> HouseImages { get; init; }

    public CreateAddressCommand CreateAddressCommand { get; init; }
    public Guid CategoryId { get; init; } 

    public Guid CategoryRentSaleId { get; init; }

    public CreateHomeSituationCommand  CreateHomeSituationCommand { get; init; }
    public CreateLocatedNearbyCommand CreateLocatedNearbyCommand { get;init; }
    public CreateThereIsInHouseCommand CreateThereIsInHouseCommand { get; init; }
    


}

public class CreateHouseCommandHandler : IRequestHandler<CreateHouseCommand>
{
    private readonly IMediator _mediator;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IApplicationDbContext _context;
    private readonly IUser _currentUser;
    public CreateHouseCommandHandler(
        IMediator mediator, 
        IApplicationDbContext context, 
        IWebHostEnvironment webHostEnvironment,
        IUser currentUser)
          => (_mediator, _context, _webHostEnvironment,_currentUser) = (mediator, context,webHostEnvironment,currentUser);
       
    

    public async Task Handle(CreateHouseCommand request, CancellationToken cancellationToken)
    {

        string rootpath = _webHostEnvironment.WebRootPath;

        string filename = Guid.NewGuid() + request.MainImage.FileName;

        string combinedPath = Path.Combine(rootpath + @"\HouseImages", filename);
        
        using (var stream = new FileStream(combinedPath, FileMode.Create))
        {
            await request.MainImage.CopyToAsync(stream);

        }
        House newHouse = new House
        {
            HouseId = Guid.NewGuid(),
            Description = request.Description,
            Price = request.Price,
            Area = request.Area,
            CountOfRoom = request.CountOfRoom,

            AddressId = await _mediator.Send(request.CreateAddressCommand),
            CategoryId = request.CategoryId,
            CategoryRentSaleId = request.CategoryRentSaleId,
            HomeSituationId = await _mediator.Send(request.CreateHomeSituationCommand),
            LocatedNearbyId = await _mediator.Send(request.CreateLocatedNearbyCommand),
            ThereIsInHouseId = await _mediator.Send(request.CreateThereIsInHouseCommand),

            CreatedAt = DateTime.UtcNow,
            CreatedBy = _currentUser.Id
            
            

        };

    }
}
