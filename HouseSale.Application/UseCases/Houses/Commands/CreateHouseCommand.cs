using HouseSale.Application.Commons.Interfaces;
using HouseSale.Application.UseCases.Addresses.Commands;
using HouseSale.Domain.Entities;
using MediatR;
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


}

//public class CreateHouseCommandHandler : IRequestHandler<CreateHouseCommand>
//{
//    private readonly IMediator _mediator;
//    private readonly IApplicationDbContext _context;
//    public CreateHouseCommandHandler(IMediator mediator, IApplicationDbContext context)
//        => (_mediator, _context)=(mediator,context);


//    //public Task Handle(CreateHouseCommand request, CancellationToken cancellationToken)
//    //{
           
//    //}
//}
