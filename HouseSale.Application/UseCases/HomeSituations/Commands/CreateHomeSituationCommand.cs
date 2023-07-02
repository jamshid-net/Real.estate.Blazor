using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities.BoolTypeEntities;
using MediatR;

namespace HouseSale.Application.UseCases.HomeSituations.Commands;
public class CreateHomeSituationCommand:IRequest<Guid>


{
    public bool Renovation { get; set; }
    public bool Average { get; set;}
    public bool RepairRequired { get; set;}
    public bool BlackPlaster { get; set;}
    public bool MakeupBeforeClean { get; set;}
    public bool Perishable { get; set;}
}

public class CreateHomeSituationCommandHandler : IRequestHandler<CreateHomeSituationCommand,Guid>
{

    private readonly IApplicationDbContext _context;

    public CreateHomeSituationCommandHandler(IApplicationDbContext context)
        => _context = context;



    public async Task<Guid> Handle(CreateHomeSituationCommand request, CancellationToken cancellationToken)
    {
        HomeSituation homeSituation = new HomeSituation
        {
            HomeSituationId = Guid.NewGuid(),
            Renovation = request.Renovation,
            Average = request.Average,
            RepairRequired = request.RepairRequired,
            BlackPlaster = request.BlackPlaster,
            MakeupBeforeClean = request.MakeupBeforeClean,
            Perishable = request.Perishable
        };
        await _context.HomeSituations.AddAsync(homeSituation,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return homeSituation.HomeSituationId;

    }
}

