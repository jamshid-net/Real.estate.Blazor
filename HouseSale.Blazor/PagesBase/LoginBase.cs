
using HouseSale.Blazor.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace HouseSale.Blazor.PagesBase;

public class LoginBase:ComponentBase
{

    protected NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string? returnUrl { get; set; }


    public LoginModel LoginModel { get; set; }  = new LoginModel();
   

    protected async Task OnSubmitLogin(EditContext context)
    {
        var LoginModel = context.Model as LoginModel;
        if(returnUrl is null)
        {
            returnUrl = "/";
        }
        
        NavigationManager.NavigateTo($"{returnUrl}", forceLoad: false);
        

    }
   


}
