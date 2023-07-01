using HouseSale.Application.Commons.Interfaces;
using HouseSale.Application.UseCases.Addresses.Commands;
using HouseSale.Application.UseCases.HomeSituations.Commands;
using HouseSale.Application.UseCases.HouseImages.Commands;
using HouseSale.Application.UseCases.LocatedNearbies.Commands;
using HouseSale.Application.UseCases.ThereIsInHouses.Commands;
using HouseSale.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace HouseSale.Application.UseCases.Houses.Commands;
public class CreateHouseCommand:IRequest
{
    public string Description { get;set; }

    public decimal Price { get;set; }

    public float Area { get;set; }

    public int CountOfRoom { get;set; }

    public IFormFile MainImage { get;set; }
    public List<IBrowserFile> HouseImages { get;set; } = new(15);

    public CreateAddressCommand CreateAddressCommand { get; set; } = new();
    public Guid CategoryId { get;set; } 

    public Guid CategoryRentSaleId { get;set; }

    public CreateHomeSituationCommand  CreateHomeSituationCommand { get;set; }
    public CreateLocatedNearbyCommand CreateLocatedNearbyCommand { get; set; }
    public CreateThereIsInHouseCommand CreateThereIsInHouseCommand { get;set; }
    


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

        string filename = Guid.NewGuid() + request.MainImage.Name;

        string combinedPath = Path.Combine(rootpath + @"\HouseImages", filename);

       
        House newHouse = new House
        {
            HouseId = Guid.NewGuid(),
            Description = request.Description,
            Price = request.Price,
            Area = request.Area,
            CountOfRoom = request.CountOfRoom,
            MainImage = "/HouseImages/" + filename,
            AddressId = await _mediator.Send(request.CreateAddressCommand),
            CategoryId = request.CategoryId,
            CategoryRentSaleId = request.CategoryRentSaleId,
            HomeSituationId = await _mediator.Send(request.CreateHomeSituationCommand),
            LocatedNearbyId = await _mediator.Send(request.CreateLocatedNearbyCommand),
            ThereIsInHouseId = await _mediator.Send(request.CreateThereIsInHouseCommand),

            CreatedAt = DateTime.UtcNow,
            CreatedBy = _currentUser.Id

        };
        _context.Houses.Add(newHouse);
        await _context.SaveChangesAsync(cancellationToken);

        //var foundHouse = await _context.Houses.FindAsync(new object[] { newHouse.HouseId }, cancellationToken);

        //if (foundHouse is not null)
        //{
        //    foreach (var photo in request.HouseImages)
        //    {
        //        string filename2 = Guid.NewGuid() + photo.FileName;
        //        string combinedPath2 = Path.Combine(rootpath + @"\HouseImages", filename2);

        //        using (var stream = new FileStream(combinedPath, FileMode.Create))
        //        {
        //            await photo.CopyToAsync(stream);

        //        }
        //        await _mediator.Send(new CreateHouseImageCommand
        //        {
        //            HouseId = foundHouse.HouseId,
        //            ImagePath = "/HouseImages/" + filename2
        //        });


        //    }
        //}
        //else throw new NotFoundException(nameof(House), newHouse.HouseId);

    }
}
