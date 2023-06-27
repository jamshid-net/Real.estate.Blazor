﻿namespace HouseSale.Domain.Entities.BoolTypeEntities;
public class HomeSituation
{
    public bool Euratom { get; set; } = false;
    public bool Average { get; set; } = false;
    public bool RepairRequired { get; set; } = false;
    public bool BlackPlaster { get; set; } = false;
    public bool MakeupBeforeClean { get; set; } = false;
    public bool Perishable { get; set; } = false;
}