using DAL.Models;

namespace API.Extension;

public static class ConverterExtensions
{
    public static API.Models.ElectricityProductionPlant ConvertToPlants(this DAL.Models.ElectricityProductionPlant plants)
    {
        return new API.Models.ElectricityProductionPlant
        {
            XtfId = plants.XtfId,
            Address = plants.Address,
            PostCode = plants.PostCode,
            Municipality = plants.Municipality,
            Canton = plants.Canton,
            BeginningOfOperation = plants.BeginningOfOperation,
            InitialPower = plants.InitialPower,
            TotalPower = plants.TotalPower,
            MainCategory = plants.MainCategory,
            SubCategory = plants.SubCategory,  
            PlantCategory = plants.PlantCategory,
            X = plants.X,
            Y = plants.Y,
        };
        
    }
    
}