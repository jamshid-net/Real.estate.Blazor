using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseSale.Application.UseCases.Addresses.Queries;
public record GetAllAddressQuery : IRequest<List<Address>>;
public class GetAllAddressQueryHandler : IRequestHandler<GetAllAddressQuery, List<Address>>
{
    private readonly IApplicationDbContext _context;

    public GetAllAddressQueryHandler(IApplicationDbContext context)
            =>_context = context;
    
    public async Task<List<Address>> Handle(GetAllAddressQuery request, CancellationToken cancellationToken)
       =>await _context.Addresses.AsNoTracking().ToListAsync(cancellationToken);
    
    
}

