using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities;
using MediatR;

namespace HouseSale.Application.UseCases.Categories.Queries;
public class GetByIdCategoryQuery : IRequest<Category>
{
    public Guid CategoryId { get; init; }
}

public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, Category>
{
    private readonly IApplicationDbContext _context;

    public GetByIdCategoryQueryHandler(IApplicationDbContext context)
        => _context = context;
    public async Task<Category> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FindAsync(new object[] { request.CategoryId }, cancellationToken);
        if (category is null)

            throw new NotFoundException(nameof(Category), request.CategoryId);


        return category;
    }
}
