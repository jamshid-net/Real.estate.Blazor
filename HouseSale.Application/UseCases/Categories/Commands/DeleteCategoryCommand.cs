using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities;
using MediatR;

namespace HouseSale.Application.UseCases.Categories.Commands;
public class DeleteCategoryCommand : IRequest
{
    public Guid CategoryId { get; init; }
}
public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCategoryCommandHandler(IApplicationDbContext context)
        => _context = context;

    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        Category? category = await _context.Categories.FindAsync(new object[] { request.CategoryId }, cancellationToken);
        if (category is null)

            throw new NotFoundException(nameof(Category), request.CategoryId);


        _context.Categories.Remove(category);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
