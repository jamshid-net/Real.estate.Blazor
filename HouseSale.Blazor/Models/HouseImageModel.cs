using HouseSale.Blazor.Attributes;
using Microsoft.AspNetCore.Components.Forms;

namespace HouseSale.Blazor.Models;

public class HouseImageModel
{
    public IBrowserFile[] Picture { get; set; }
}
