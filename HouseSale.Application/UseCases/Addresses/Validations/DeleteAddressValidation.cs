using FluentValidation;
using HouseSale.Application.UseCases.Addresses.Commands;


namespace HouseSale.Application.UseCases.Addresses.Validations;
public class DeleteAddressValidation:AbstractValidator<DeleteAddressCommand>
{
    public DeleteAddressValidation()
    {   
        RuleFor(x => x.AddressId).NotEmpty().NotNull();
    }
}
