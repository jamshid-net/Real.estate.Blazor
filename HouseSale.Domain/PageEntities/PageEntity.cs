namespace HouseSale.Domain.PageEntities;
public class PageEntity
{

    public Guid PageEntityId { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }
    public string[]? ImagesPath { get; set; }
    public string? OtherText { get; set; }


}
