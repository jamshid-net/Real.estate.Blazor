using HouseSale.Application.Commons.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSale.Application.UseCases.HomeSituations.Commands;
public class CreateHomeSituationCommand:IRequest
{
    public bool Renovation { get; init; }
    public bool Average { get; init;}
    public bool RepairRequired { get; init;}
    public bool BlackPlaster { get; init;}
    public bool MakeupBeforeClean { get; init;}
    public bool Perishable { get; init;}
}
//public class CreateHomeSituationCommandHandler : IRequestHandler<CreateHomeSituationCommand>
//{

//    private readonly IApplicationDbContext _context;

//    public CreateHomeSituationCommandHandler(IApplicationDbContext context)
//        =>_context = context;
    
    

//    public Task Handle(CreateHomeSituationCommand request, CancellationToken cancellationToken)
//    {
        

//    }
//}
