namespace HouseSale.Domain.Entities.BoolTypeEntities;
public class LocatedNearby
{

    public Guid LocatedNearbyId { get; set; }

    public bool Hospital { get; set; } = false;
    public bool Playground { get; set; } = false;
    public bool Kindergarten { get; set; } = false;
    public bool Stations { get; set; } = false;
    public bool Park { get; set; } = false;
    public bool EntertainmentInstitutions { get; set; } = false;
    public bool Restaurants { get; set; } = false;
    public bool Residence { get; set; } = false;
    public bool Supermarkets { get; set; } = false;
    public bool School { get; set; } = false;

    //public Guid HouseId { get; set; }
    public virtual House House { get; set; }
}
