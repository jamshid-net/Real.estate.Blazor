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
using System.ComponentModel;

namespace HouseSale.Application.UseCases.Houses.Commands;
public class CreateHouseCommand:IRequest
{
    public string Description { get;set; }

    public decimal Price { get;set; }

    public float Area { get;set; }

    public int CountOfRoom { get;set; }


    public string MainImage { get;set; }
    public List<string> HouseImages { get;set; } = new(15);


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
    private readonly IApplicationDbContext _context;
    private readonly IUser _currentUser;
    public CreateHouseCommandHandler(
        IMediator mediator, 
        IApplicationDbContext context,
        IUser currentUser)

          => (_mediator, _context,_currentUser) = (mediator, context,currentUser);




    public async Task Handle(CreateHouseCommand request, CancellationToken cancellationToken)
    {

       
        House newHouse = new House
        {
            HouseId = Guid.NewGuid(),
            Description = request.Description,
            Price = request.Price,
            Area = request.Area,
            CountOfRoom = request.CountOfRoom,

            MainImage = request.MainImage,

            AddressId = await _mediator.Send(request.CreateAddressCommand),
            CategoryId = request.CategoryId,
            CategoryRentSaleId = request.CategoryRentSaleId,
            CategoryHomeSituationId = await _mediator.Send(request.CreateHomeSituationCommand),
            LocatedNearbyId = await _mediator.Send(request.CreateLocatedNearbyCommand),
            ThereIsInHouseId = await _mediator.Send(request.CreateThereIsInHouseCommand),

            CreatedAt = DateTime.UtcNow,
            CreatedBy = _currentUser.Id

        };
        _context.Houses.Add(newHouse);
        await _context.SaveChangesAsync(cancellationToken);



        var foundHouse = await _context.Houses.FindAsync(new object[] { newHouse.HouseId }, cancellationToken);


        if (foundHouse is not null)
        {
            foreach (var photo in request.HouseImages)
            {

                await _mediator.Send(new CreateHouseImageCommand() { HouseId = foundHouse.HouseId, ImagePath = photo });
            }

        }
        else throw new NotFoundException(nameof(House), newHouse.HouseId);


    }
}
