using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class SubCategoryCatalogue
{
    public string CatalogueId { get; set; } = null!;

    public string De { get; set; } = null!;

    public string Fr { get; set; } = null!;

    public string It { get; set; } = null!;

    public string En { get; set; } = null!;

    public virtual ICollection<ElectricityProductionPlant> ElectricityProductionPlants { get; } = new List<ElectricityProductionPlant>();
}
