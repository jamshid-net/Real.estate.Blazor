using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseSale.Application.UseCases.Categories.Queries;
public record GetAllCategoryQuery : IRequest<List<Category>>;
public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<Category>>
{
    private readonly IApplicationDbContext _context;

    public GetAllCategoryQueryHandler(IApplicationDbContext context)    
        => _context = context;
    public async Task<List<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        => await _context.Categories.AsNoTracking().ToListAsync(cancellationToken);
}
