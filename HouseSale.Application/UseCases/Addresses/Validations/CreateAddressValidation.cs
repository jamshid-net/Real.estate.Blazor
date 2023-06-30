using FluentValidation;
using HouseSale.Application.UseCases.Addresses.Commands;

namespace HouseSale.Application.UseCases.Addresses.Validations;
public class CreateAddressValidation:AbstractValidator<CreateAddressCommand>
{
    public CreateAddressValidation()
    {
        RuleFor(x=> x.City).NotEmpty().WithMessage("City is required!");
        RuleFor(x=> x.Street).NotEmpty().WithMessage("Street is required!");
        RuleFor(x=> x.State).NotEmpty().WithMessage("State is required!");
        RuleFor(x=> x.Country).NotEmpty().WithMessage("State is required!");
       
    }
}
