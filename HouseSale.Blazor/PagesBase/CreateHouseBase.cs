using HouseSale.Application.UseCases.Houses.Commands;
using HouseSale.Blazor.Models;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HouseSale.Blazor.PagesBase;

public class CreateHouseBase:ComponentBase
{
    protected CreateHouseCommand CreateHouseCommand = new();


    protected HouseImageModel houseImagemodel;

    protected IMediator mediator { get; set; }


    protected EditContext editContext;


   

    protected IList<string> imageDataUrls = new List<string>();
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

    protected async Task OnSubmitHouse(EditContext context)
    {
        var model = context.Model as CreateHouseCommand;


    }

    


}


