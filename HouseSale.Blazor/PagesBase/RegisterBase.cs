using HouseSale.Blazor.Models;
using Microsoft.AspNetCore.Components;

namespace HouseSale.Blazor.PagesBase;

public class RegisterBase : ComponentBase
{
    public RegisterModels RegisterModels { get; set; } = new RegisterModels();
}
