using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseSale.Application.UseCases.CategoryRentSales.Queries;
public record GetAllCategoryRentSaleQuery : IRequest<List<CategoryRentSale>>;
public class GetAllCategoryRentSaleQueryHandler : IRequestHandler<GetAllCategoryRentSaleQuery, List<CategoryRentSale>>
{
    private readonly IApplicationDbContext _context;

    public GetAllCategoryRentSaleQueryHandler(IApplicationDbContext context)
        => _context = context;
    public async Task<List<CategoryRentSale>> Handle(GetAllCategoryRentSaleQuery request, CancellationToken cancellationToken)
        => await _context.CategoryRentSales.AsNoTracking().ToListAsync(cancellationToken);
}
