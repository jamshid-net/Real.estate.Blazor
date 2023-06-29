using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities.BoolTypeEntities;
using MediatR;
using Microsoft.AspNetCore.Builder;

namespace HouseSale.Application.UseCases.HomeSituations.Commands;
public class DeleteHomeSituationCommand:IRequest
{
    public Guid HomeSituationId { get; init; }
}
public class DeleteHomeSituationCommandHandler : IRequestHandler<DeleteHomeSituationCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteHomeSituationCommandHandler(IApplicationDbContext context)
        =>_context = context;



    public async Task Handle(DeleteHomeSituationCommand request, CancellationToken cancellationToken)
    {
        var foundHomeSituation = await _context.HomeSituations.FindAsync(new object[] {request.HomeSituationId},cancellationToken);
        if (foundHomeSituation is null)
            throw new NotFoundException(nameof(HomeSituation), request.HomeSituationId);
        _context.HomeSituations.Remove(foundHomeSituation);
        await _context.SaveChangesAsync(cancellationToken);

    }
}
