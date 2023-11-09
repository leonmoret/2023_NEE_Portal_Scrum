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


    public async Task<IActionResult> Index()
    {
        var plants = await _plantServices.GetElectricityProductionPlant();
        
        // get current year
        var currentYear = DateTime.Now.Year;
        
        // get plants where date is current date
        var PVkWhThisYear = plants.Where(p => p.BeginningOfOperation.Year == currentYear).Where(p => p.SubCategory == "subcat_2")
            .ToList();
        var totalPVkWhThisYear = PVkWhThisYear.Sum(p => p.TotalPower);
        
        var PVkWhLastYear = plants.Where(p => p.BeginningOfOperation.Year == currentYear - 1).Where(p => p.SubCategory == "subcat_2")
            .ToList();
        var totalPVkWhLastYear = PVkWhLastYear.Sum(p => p.TotalPower);
        
        var WTkWhThisYear = plants.Where(p => p.BeginningOfOperation.Year == currentYear).Where(p => p.SubCategory == "subcat_3")
            .ToList();
        var totalWTkWhThisYear = WTkWhThisYear.Sum(p => p.TotalPower);
        
        var WTkWhLastYear = plants.Where(p => p.BeginningOfOperation.Year == currentYear - 1).Where(p => p.SubCategory == "subcat_3")
            .ToList();
        var totalWTkWhLastYear = WTkWhLastYear.Sum(p => p.TotalPower);
        
        return View(new BarChartViewModel(totalPVkWhThisYear, totalWTkWhThisYear, totalPVkWhLastYear, totalWTkWhLastYear));
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
