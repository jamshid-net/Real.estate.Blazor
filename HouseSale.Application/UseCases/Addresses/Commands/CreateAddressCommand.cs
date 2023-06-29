using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities;
using MediatR;

namespace HouseSale.Application.UseCases.Addresses.Commands;
public class CreateAddressCommand:IRequest<Guid>
{

    public string Street { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string Country { get; init; }
}

public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand,Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateAddressCommandHandler(IApplicationDbContext context)
            =>_context = context;
    
    
    public async Task<Guid> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        Address address = new Address
        {
            AddressId = Guid.NewGuid(),
            Street = request.Street,
            City = request.City,
            State = request.State,
            Country = request.Country
        };
        await _context.Addresses.AddAsync(address,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return address.AddressId;

    }
}
