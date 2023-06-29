
using HouseSale.Application.Commons.Interfaces;

using HouseSale.Domain.Entities;
using MediatR;

namespace HouseSale.Application.UseCases.Addresses.Queries;
public class GetByIdAddressQuery : IRequest<Address>
{
    public Guid AddressId { get; init; }
}
public class GetByIdAddressQueryHandler : IRequestHandler<GetByIdAddressQuery, Address>
{
    private readonly IApplicationDbContext _context;

    public GetByIdAddressQueryHandler(IApplicationDbContext context)
            => _context = context;
    public async Task<Address> Handle(GetByIdAddressQuery request, CancellationToken cancellationToken)
    {
        var foundAddress = await _context.Addresses.FindAsync(new object[] { request.AddressId }, cancellationToken);
        if (foundAddress is null)
            throw new NotFoundException(nameof(Address), request.AddressId);

        return foundAddress;
    }
}
