using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities.BoolTypeEntities;
using MediatR;

namespace HouseSale.Application.UseCases.HomeSituations.Commands;
public class UpdateHomeSituationCommand:IRequest
{
    public Guid HomeSituationId { get; set; }
    public bool Renovation { get; init; }
    public bool Average { get; init; }
    public bool RepairRequired { get; init; }
    public bool BlackPlaster { get; init; }
    public bool MakeupBeforeClean { get; init; }
    public bool Perishable { get; init; }
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
            throw new NotFoundException(nameof(HomeSituation), request.HomeSituationId);

        foundHomeSituation.Renovation = request.Renovation;
        foundHomeSituation.Average = request.Average;   
        foundHomeSituation.RepairRequired = request.RepairRequired;
        foundHomeSituation.BlackPlaster = request.BlackPlaster;
        foundHomeSituation.MakeupBeforeClean = request.MakeupBeforeClean;
        foundHomeSituation.Perishable = request.Perishable;

        await _context.SaveChangesAsync(cancellationToken);

    }
}
