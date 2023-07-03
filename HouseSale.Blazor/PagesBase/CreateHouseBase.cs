using HouseSale.Application.UseCases.Houses.Commands;
using HouseSale.Blazor.Models;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.SqlServer.Server;

namespace HouseSale.Blazor.PagesBase;

public class CreateHouseBase:ComponentBase
{
    protected CreateHouseCommand CreateHouseCommand = new();

    
    protected HouseImageModel houseImagemodel;



    //sing file upload image
    protected  IBrowserFile SingleImage;
    //--------------------



    protected IMediator mediator { get; set; }


    protected EditContext editContext;

    [Inject]
    private IWebHostEnvironment env { get; set; }


    protected IList<string> imageDataUrls = new List<string>();

    protected string singleImageUrl = string.Empty;
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
    protected async Task UploadSingleImage(InputFileChangeEventArgs image)
    {
        SingleImage = null;
        var format = "image/png";
        SingleImage = image.File;
        var resizedImageFile = await SingleImage.RequestImageFileAsync(format, 300, 300);
        var buffer = new byte[resizedImageFile.Size];
        await resizedImageFile.OpenReadStream().ReadAsync(buffer);
        
        singleImageUrl=  $"data:{format};base64,{Convert.ToBase64String(buffer)}";
  
        editContext.NotifyFieldChanged(FieldIdentifier.Create(() => SingleImage));
       
    }

    protected async Task OnSubmitHouse(EditContext context)
    {
        


        var model = context.Model as CreateHouseCommand;


    }

    


}


