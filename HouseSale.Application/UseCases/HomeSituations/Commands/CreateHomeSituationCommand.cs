using HouseSale.Application.Commons.Interfaces;
<<<<<<< HEAD
using HouseSale.Domain.Entities.BoolTypeEntities;
using MediatR;

namespace HouseSale.Application.UseCases.HomeSituations.Commands;
public class CreateHomeSituationCommand:IRequest<Guid>
=======
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSale.Application.UseCases.HomeSituations.Commands;
public class CreateHomeSituationCommand:IRequest
>>>>>>> b1c8d7c482d61c85eec7f0b848b7428bb805ba8f
{
    public bool Renovation { get; init; }
    public bool Average { get; init;}
    public bool RepairRequired { get; init;}
    public bool BlackPlaster { get; init;}
    public bool MakeupBeforeClean { get; init;}
    public bool Perishable { get; init;}
}
<<<<<<< HEAD
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
=======
//public class CreateHomeSituationCommandHandler : IRequestHandler<CreateHomeSituationCommand>
//{

//    private readonly IApplicationDbContext _context;

//    public CreateHomeSituationCommandHandler(IApplicationDbContext context)
//        =>_context = context;
    
    

//    public Task Handle(CreateHomeSituationCommand request, CancellationToken cancellationToken)
//    {
        

//    }
//}
>>>>>>> b1c8d7c482d61c85eec7f0b848b7428bb805ba8f
