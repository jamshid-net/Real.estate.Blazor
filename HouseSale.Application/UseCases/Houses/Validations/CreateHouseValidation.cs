
using FluentValidation;

using HouseSale.Application.UseCases.Addresses.Commands;
using HouseSale.Application.UseCases.Houses.Commands;


namespace HouseSale.Application.UseCases.Houses.Validations;
public class CreateHouseValidation:AbstractValidator<CreateHouseCommand>
{
    
    public CreateHouseValidation()
    {
        RuleFor(x => x.Price).GreaterThan(10).WithMessage("Price must be greater than 10$").NotEmpty().WithMessage("Must be not empty");
        RuleFor(x => x.Area).NotEmpty().WithMessage("Must be not empty").GreaterThan(10).WithMessage("Area must greater than 10");
        RuleFor(x => x.CountOfRoom).NotEmpty().WithMessage("Count of room should be not empty value").GreaterThan(1);
        

       //RuleFor(x => x.MainImage.Length).GreaterThan(0).WithMessage("Please set image!").LessThan(2000).WithMessage("file size is big");

        
        RuleFor(x => x.CategoryId).NotNull().WithMessage("Please choose category");
        RuleFor(x => x.CategoryRentSaleId).NotNull().WithMessage("Please choose category rent sale");
        
    }
}
