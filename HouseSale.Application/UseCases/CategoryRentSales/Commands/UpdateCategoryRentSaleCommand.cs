using HouseSale.Application.Commons.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSale.Application.UseCases.CategoryRentSales.Commands;
public class UpdateCategoryRentSaleCommand : IRequest
{
    public Guid CategoryRentSaleId { get; set; }
    public string CategoryRentSaleName { get; set; }
}

public class UpdateCategoryRentSaleCommandHandler : IRequestHandler<UpdateCategoryRentSaleCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryRentSaleCommandHandler(IApplicationDbContext context)
        => _context = context;
    public async Task Handle(UpdateCategoryRentSaleCommand request, CancellationToken cancellationToken)
    {
        var categoryRentSale = await _context.CategoryRentSales.FindAsync(new object[] { request.CategoryRentSaleId }, cancellationToken);
        if (categoryRentSale is null)
            throw new NotFoundException();
        categoryRentSale.CategoryRentSaleName = request.CategoryRentSaleName;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
