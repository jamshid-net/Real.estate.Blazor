using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSale.Application.UseCases.CategoryRentSales.Queries;
public class GetByIdCategoryRentSaleQuery : IRequest<CategoryRentSale>
{
    public Guid CategoryRentSaleId { get; set; }
}

public class GetByIdCategoryRentSaleQueryHandler : IRequestHandler<GetByIdCategoryRentSaleQuery, CategoryRentSale>
{
    private readonly IApplicationDbContext _context;

    public GetByIdCategoryRentSaleQueryHandler(IApplicationDbContext context)
        => _context = context;
    public async Task<CategoryRentSale> Handle(GetByIdCategoryRentSaleQuery request, CancellationToken cancellationToken)
    {
        var categoryRentSale = await _context.CategoryRentSales.FindAsync(new object[] { request.CategoryRentSaleId }, cancellationToken);
        if (categoryRentSale is null)
            throw new NotFoundException();

        return categoryRentSale;
    }
}
