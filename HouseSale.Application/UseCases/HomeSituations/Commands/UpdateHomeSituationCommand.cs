using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities;
using MediatR;

namespace HouseSale.Application.UseCases.HomeSituations.Commands;
public class UpdateHomeSituationCommand:IRequest
{
    public Guid HomeSituationId { get; set; }
    public string HomeSituationName { get; set; }
}
public class UpdateHomeSituationCommandHandler : IRequestHandler<UpdateHomeSituationCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateHomeSituationCommandHandler(IApplicationDbContext context)
            =>_context = context;
    
    

    public async Task Handle(UpdateHomeSituationCommand request, CancellationToken cancellationToken)
    {
        var foundHomeSituation = await _context.HomeSituations.FindAsync(new object[] { request.HomeSituationId }, cancellationToken);
        if (foundHomeSituation is null)
            throw new NotFoundException(nameof(CategoryHomeSituation), request.HomeSituationId);

        foundHomeSituation.HomeSituationName = request.HomeSituationName;

        await _context.SaveChangesAsync(cancellationToken);

    }
}
