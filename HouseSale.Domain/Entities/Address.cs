using System.Text.Json.Serialization;

namespace HouseSale.Domain.Entities;
public class Address
{
    public Guid AddressId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    [JsonIgnore]
    public virtual List<House>? Houses { get; set; }    
}
