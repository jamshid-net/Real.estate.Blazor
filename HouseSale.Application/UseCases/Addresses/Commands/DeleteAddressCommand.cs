using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities;
using MediatR;

namespace HouseSale.Application.UseCases.Addresses.Commands;
public class DeleteAddressCommand : IRequest
{
    public Guid AddressId { get; init; }
}
public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteAddressCommandHandler(IApplicationDbContext context)
           => _context = context;


    public async Task Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        var foundAddress = await _context.Addresses.FindAsync(new object[] { request.AddressId }, cancellationToken);
        if (foundAddress is null)
            throw new NotFoundException(nameof(Address),request.AddressId);

        _context.Addresses.Remove(foundAddress);

        await _context.SaveChangesAsync(cancellationToken);


    }

}
