using MVCClient.Models;

namespace MVCClient.Services;

public interface IPlantServices
{
    public Task<List<ElectricityProductionPlant>> GetElectricityProductionPlant();

}