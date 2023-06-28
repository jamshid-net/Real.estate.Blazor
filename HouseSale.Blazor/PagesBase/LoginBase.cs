
using HouseSale.Blazor.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;


namespace HouseSale.Blazor.PagesBase;

public class LoginBase:ComponentBase
{

    public LoginModel LoginModel { get; set; }  = new LoginModel();


    protected async Task OnSubmitLogin(EditContext context)
    {
        var LoginModel = context.Model as LoginModel;
       
        
    }



}
