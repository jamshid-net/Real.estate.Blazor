using FluentValidation;
using HouseSale.Application.Commons.Validation;

namespace HouseSale.Blazor.Models;

public class HouseImageValidation:AbstractValidator<HouseImageModel>
{
    public HouseImageValidation()
    {
        RuleFor(x => x.Picture)
            .NotEmpty().WithMessage("Please select at least one file.")
            .ForEach(file => file.SetValidator(new FileValidation()));
    }
}

