using HouseSale.Application.UseCases.Houses.Commands;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;




namespace HouseSale.Blazor.PagesBase;

public class CreateHouseBase:ComponentBase
{
    protected CreateHouseCommand CreateHouseCommand = new();
    
    protected IMediator mediator { get; set; }


    //protected override Task OnInitializedAsync()
    //{
       
    //}

    protected async Task OnSubmitHouse(EditContext context)
    {
        var model = context.Model as CreateHouseCommand;

       
    }

    protected async Task LoadMainImage(InputFileChangeEventArgs file)
    {
        
    }


}


