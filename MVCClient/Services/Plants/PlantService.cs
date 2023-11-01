using MVCClient.Models;

namespace MVCClient.Services.Plants
{
    public class PlantService : IPlantService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public PlantService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["API:BaseUrl"];
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
    }
}
