using Blazored.FluentValidation;
using HouseSale.Application.UseCases.Categories.Queries;
using HouseSale.Application.UseCases.CategoryRentSales.Queries;
using HouseSale.Application.UseCases.Houses.Commands;
using HouseSale.Blazor.Attributes;
using HouseSale.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.ComponentModel.DataAnnotations;

namespace HouseSale.Blazor.PagesBase;

public class CreateHouseBase:ComponentBase
{
    protected CreateHouseCommand CreateHouseCommand = new();




    protected HouseImageModel houseImagemodel;

    protected IMediator mediator { get; set; }


    protected EditContext editContext;
  

    protected async Task OnSubmitHouse(EditContext context)
    {
        var model = context.Model as CreateHouseCommand;

       
    }
    private IList<string> imageDataUrls = new List<string>();
    private int Total;
    protected async Task UploadFileChange(InputFileChangeEventArgs file)
    {
        houseImagemodel.Picture = file.GetMultipleFiles().ToArray();

        var format = "image/png";
        Total = file.GetMultipleFiles().Count();
        foreach (var imageFile in file.GetMultipleFiles())
        {
            var resizedImageFile = await imageFile.RequestImageFileAsync(format, 100, 100);
            var buffer = new byte[resizedImageFile.Size];
            await resizedImageFile.OpenReadStream().ReadAsync(buffer);
            var imageDataUrl = $"data:{format};base64,{Convert.ToBase64String(buffer)}";
            imageDataUrls.Add(imageDataUrl);
        }
        editContext.NotifyFieldChanged(FieldIdentifier.Create(() => houseImagemodel.Picture));

    }


    

}
public class HouseImageModel
{
    [Required]
    [FileValidation(new[] { ".png", ".jpg" ,".jpeg" })]
    public IBrowserFile[] Picture { get; set; }
}

