namespace HouseSale.Domain.Entities;
public class CategoryHomeSituation
{
    public Guid CategoryHomeSituationId { get; set; }
    public string HomeSituationName { get; set; }
    public virtual List<House>? Houses { get; set; }
}
