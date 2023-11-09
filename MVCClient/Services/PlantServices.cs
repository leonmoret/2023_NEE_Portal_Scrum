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
    
    public async Task<List<ElectricityProductionPlant>> GetElectricityProductionPlant()
    {
        var response = await _httpClient.GetAsync(_baseUrl + "Plants");
        if (!response.IsSuccessStatusCode) return null;
        
        var plants = await response.Content.ReadFromJsonAsync<List<ElectricityProductionPlant>>();
        
        return plants;
    }
}