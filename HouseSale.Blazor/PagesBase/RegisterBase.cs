using HouseSale.Blazor.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace HouseSale.Blazor.PagesBase;

public class RegisterBase : ComponentBase
{
    protected NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string? ReturnUrl { get; set; }

    public RegisterModels RegisterModels { get; set; } = new RegisterModels();

    protected async Task OnSubmitRegister(EditContext context)
    {
        var registerModel = context.Model as RegisterModels;
        if (ReturnUrl is null)
            ReturnUrl = "/";

        NavigationManager.NavigateTo($"{ReturnUrl}", forceLoad: false);


    }
}
