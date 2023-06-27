using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSale.Domain.PageEntities;
public class SocialContact
{
    public Guid Id { get; set; }
    public string? Type { get; set; }
    public string? Link { get; set; }
    
}
