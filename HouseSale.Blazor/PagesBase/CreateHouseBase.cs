using HouseSale.Application.UseCases.Houses.Commands;
using HouseSale.Blazor.Models;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.SqlServer.Server;
using System;

namespace HouseSale.Blazor.PagesBase;

public class CreateHouseBase:ComponentBase
{
    protected CreateHouseCommand CreateHouseCommand = new();

    
    protected HouseImageModel houseImagemodel;

    protected CancellationTokenSource cancelation;
    private int progressPercent;
    //sing file upload image
    protected  IBrowserFile SingleImage;
    //--------------------

    protected IMediator mediator { get; set; }

    private bool displayProgress;
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
        var rootPath = env.WebRootPath;
        var model = context.Model as CreateHouseCommand;

        for (int i = 0; i < Total; i++)
        {
            var imageName =Guid.NewGuid()+ houseImagemodel.Picture[i].Name;
            var fullPath = Path.Combine(rootPath + @"\HouseImages", imageName);   
            
            using var file = File.OpenWrite(fullPath);
            using var stream = houseImagemodel.Picture[i].OpenReadStream(968435456);

            var buffer = new byte[4 * 1096];
            int bytesRead;
            double totalRead = 0;

            displayProgress = true;

            while ((bytesRead = await stream.ReadAsync(buffer, cancelation.Token)) != 0)
            {
                totalRead += bytesRead;
                await file.WriteAsync(buffer, cancelation.Token);

                progressPercent = (int)((totalRead / houseImagemodel.Picture[i].Size) * 100);
                StateHasChanged();
            }

            displayProgress = false;
            model.HouseImages.Add(fullPath);
        }
       await mediator.Send(model);


        

    }

    


}


