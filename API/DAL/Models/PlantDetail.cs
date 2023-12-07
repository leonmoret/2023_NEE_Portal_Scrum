using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class PlantDetail
{
    public string XtfId { get; set; } = null!;

    public DateTime Date { get; set; }

    public double Power { get; set; }

    public string? Inclination { get; set; }

    public string? Orientation { get; set; }

    public string? PlantCategory { get; set; }

    public int ElectricityProductionPlantR { get; set; }

    public virtual ElectricityProductionPlant ElectricityProductionPlantRNavigation { get; set; } = null!;

    public virtual OrientationCatalogue? OrientationNavigation { get; set; }

    public virtual PlantCategoryCatalogue? PlantCategoryNavigation { get; set; }
}
