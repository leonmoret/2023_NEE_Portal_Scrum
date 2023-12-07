using MVCClient.Models;

namespace MVCClient.Services;

public class PlantServices : IPlantServices
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;
    
    public PlantServices(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _baseUrl = configuration["WebAPI:BaseUrl"];
    }
    
    public async Task<List<Plant>> GetPlants()
    {
        var response = await _httpClient.GetAsync(_baseUrl + "/Plant");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<Plant>>();
        }

        return new List<Plant>();
    }

    public async Task<List<ProductionVS>> GetProductionVS()
    {
        var response = await _httpClient.GetAsync(_baseUrl + "Plants");
        if (!response.IsSuccessStatusCode) return null;
        
        var plants = await response.Content.ReadFromJsonAsync<List<ProductionVS>>();
        
        return plants;
    }
}