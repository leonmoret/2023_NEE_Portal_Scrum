using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCClient.Models;
using MVCClient.Services.Plants;

namespace MVCClient.Controllers;

public class PlantController : Controller
{
    private readonly ILogger<PlantController> _logger;
    private readonly IPlantService _plantService;

    public PlantController(ILogger<PlantController> logger, IPlantService plantService)
    {
        _logger = logger;
        _plantService = plantService;
    }

    public async Task<IActionResult> Index()
    {
        var plants = await _plantService.GetPlants();

        return View(plants);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}