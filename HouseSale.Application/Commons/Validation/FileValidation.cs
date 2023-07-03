using FluentValidation;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSale.Application.Commons.Validation;

public class FileValidation : AbstractValidator<IBrowserFile>
{
    public FileValidation()
    {
        RuleFor(file => file.Name)
            .NotEmpty().WithMessage("Please select a file.")
            .Must(BeSupportedExtension).WithMessage("Unsupported file extension.");
    }

    private bool BeSupportedExtension(string fileName)
    {
        var supportedExtensions = new[] { ".png", ".jpg" };
        var extension = System.IO.Path.GetExtension(fileName);
        return supportedExtensions.Contains(extension);
    }
}