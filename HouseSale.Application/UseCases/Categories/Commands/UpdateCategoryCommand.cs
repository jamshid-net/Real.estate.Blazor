using HouseSale.Application.Commons.Interfaces;
using MediatR;

namespace HouseSale.Application.UseCases.Categories.Commands;
public class UpdateCategoryCommand : IRequest
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context)
        => _context = context;

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FindAsync(new object[] { request.CategoryId }, cancellationToken);
        if (category is null)
            throw new NotFoundException();

        category.CategoryName = request.CategoryName;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
