using HouseSale.Application.Commons.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSale.Application.UseCases.Addresses.Commands;
public class UpdateAddressCommand:IRequest
{
    public Guid AddressId { get; init; }
    public string Street { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string Country { get; init; }
}
public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateAddressCommandHandler(IApplicationDbContext context) 
        => _context = context;

    public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var foundAddress = await _context.Addresses.FindAsync(new object[] { request.AddressId }, cancellationToken);
        if (foundAddress is null)
            throw new NotFoundException();

        foundAddress.Street = request.Street;
        foundAddress.City = request.City;
        foundAddress.State = request.State;
        foundAddress.Country = request.Country;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
