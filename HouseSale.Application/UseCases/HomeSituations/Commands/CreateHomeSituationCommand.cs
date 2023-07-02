using HouseSale.Application.Commons.Interfaces;
using HouseSale.Domain.Entities;
using MediatR;

namespace HouseSale.Application.UseCases.HomeSituations.Commands;
public class CreateHomeSituationCommand:IRequest<Guid>
{

    public string HomeSituationName { get; set; }

}

public class CreateHomeSituationCommandHandler : IRequestHandler<CreateHomeSituationCommand,Guid>
{

    private readonly IApplicationDbContext _context;

    public CreateHomeSituationCommandHandler(IApplicationDbContext context)
        => _context = context;



    public async Task<Guid> Handle(CreateHomeSituationCommand request, CancellationToken cancellationToken)
    {
        CategoryHomeSituation homeSituation = new CategoryHomeSituation
        {
            HomeSituationName = request.HomeSituationName
        };
        await _context.HomeSituations.AddAsync(homeSituation,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return homeSituation.HomeSituationId;

    }
}

