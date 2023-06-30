using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities;
using MediatR;

namespace HouseSale.Application.UseCases.CategoryRentSales.Commands;
public class CreateCategoryRentSaleCommand : IRequest<Guid>
{
    public string CategoryRentSaleName { get; init; }
}

public class CreateCategoryRentSaleCommandHandler : IRequestHandler<CreateCategoryRentSaleCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoryRentSaleCommandHandler(IApplicationDbContext context)
        => _context = context;
    public async Task<Guid> Handle(CreateCategoryRentSaleCommand request, CancellationToken cancellationToken)
    {
        CategoryRentSale categoryRentSale = new CategoryRentSale
        {
            CategoryRentSaleName = request.CategoryRentSaleName
        };
        await _context.CategoryRentSales.AddAsync(categoryRentSale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return categoryRentSale.CategoryRentSaleId;
    }
}
