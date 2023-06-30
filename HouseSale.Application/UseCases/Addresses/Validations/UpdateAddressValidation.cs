using FluentValidation;
using HouseSale.Application.UseCases.Addresses.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSale.Application.UseCases.Addresses.Validations;
public class UpdateAddressValidation:AbstractValidator<UpdateAddressCommand>
{
    public UpdateAddressValidation()
    {
        RuleFor(x=> x.AddressId).NotEmpty();
        RuleFor(x => x.City).NotEmpty().WithMessage("City is required!");
        RuleFor(x => x.Street).NotEmpty().WithMessage("Street is required!");
        RuleFor(x => x.State).NotEmpty().WithMessage("State is required!");
        RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required!");
    }
 
}
