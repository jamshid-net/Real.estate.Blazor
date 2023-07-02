namespace HouseSale.Domain.Entities;
public class CategoryHomeSituation
{
    public Guid HomeSituationId { get; set; }
    public string HomeSituationName { get; set; }
    public virtual List<House>? House { get; set; }
}
