using MVCClient.Models;

namespace MVCClient.Services;

public interface IPlantServices
{
    public Task<List<ProductionVS>> GetProductionVS();
    
    public Task<List<Plant>> GetPlants();

}