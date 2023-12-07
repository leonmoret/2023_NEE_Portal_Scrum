using API.Models;
using DAL.Models;

namespace API.Extension;

public static class ConverterExtensions
{
    public static ProductionVS ConvertToProductionVS(this ProductionV productionV)
    {
        if (productionV.SubCategory == "subcat_1")
        {
            productionV.SubCategory = "mini-hydraulic";
        }
        if (productionV.SubCategory == "subcat_2")
        {
            productionV.SubCategory = "PV";
        }
        if (productionV.SubCategory == "subcat_3")
        {
            productionV.SubCategory = "Windturbine";
        }
        if (productionV.SubCategory == "subcat_4")
        {
            productionV.SubCategory = "Bio-gas";
        }
        return new ProductionVS
        {
               Gwh = productionV.Gwh ?? 0,
               Gwh_Total = productionV.GwhTotal ?? 0,
               Year = productionV.Year ?? 0,
               SubCategory = productionV.SubCategory ?? ""
        };
    }
}