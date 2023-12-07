using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class ProductionV
{
    public int IdProductionVs { get; set; }

    public int? Gwh { get; set; }

    public int? GwhTotal { get; set; }

    public int? Year { get; set; }

    public string? SubCategory { get; set; }

    public virtual SubCategoryCatalogue? SubCategoryNavigation { get; set; }
}
