using HouseSale.Application.Commons.Interfaces;

using HouseSale.Domain.Entities;

using MediatR;

namespace HouseSale.Application.UseCases.CategoryRentSales.Commands;
public class DeleteCategoryRentSaleCommand : IRequest
{
    public Guid CategoryRentSaleId { get; init; }
}
public class DeleteCategoryRentSaleCommandHandler : IRequestHandler<DeleteCategoryRentSaleCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCategoryRentSaleCommandHandler(IApplicationDbContext context)
        => _context = context;
    public async Task Handle(DeleteCategoryRentSaleCommand request, CancellationToken cancellationToken)
    {
        var categoryRentSale = await _context.CategoryRentSales.FindAsync(new object[] { request.CategoryRentSaleId }, cancellationToken);
        if (categoryRentSale is null)

            throw new NotFoundException(nameof(CategoryRentSale),request.CategoryRentSaleId);


        _context.CategoryRentSales.Remove(categoryRentSale);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
