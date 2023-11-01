using MVCClient.Models;

namespace MVCClient.Services.Plants
{
    public interface IPlantService
    {
        public Task<List<Plant>> GetPlants();
    }
}
