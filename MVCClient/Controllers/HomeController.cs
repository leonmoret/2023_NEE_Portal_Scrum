using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCClient.Models;
using MVCClient.Services;

namespace MVCClient.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPlantServices _plantServices;

    public HomeController(ILogger<HomeController> logger, IPlantServices plantServices)
    {
        _logger = logger;
        _plantServices = plantServices;
    }

    public async Task<IActionResult>  Index()
    {
        var plants = await _plantServices.GetProductionVS();
        
        // var gwh_PV_2017 = plants.Where(p => p.Year == 2017).Where(p => p.SubCategory == "subcat_2").Select(p=>p.Gwh);
        // var gwh_PV_2018 = plants.Where(p => p.Year == 2018).Where(p => p.SubCategory == "subcat_2").Select(p=>p.Gwh);
        // var gwh_Hydr_2017 = plants.Where(p => p.Year == 2017).Where(p => p.SubCategory == "subcat_1").Select(p=>p.Gwh);
        // var gwh_Hydr_2018 = plants.Where(p => p.Year == 2018).Where(p => p.SubCategory == "subcat_1").Select(p=>p.Gwh);
        
        
        return View(plants);
    }
    

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}