using API.Extension;
using DAL;
using API.Models;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ElectricityProductionPlant = API.Models.ElectricityProductionPlant;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class PlantsController : ControllerBase
{
    private readonly DatabaseNeePortal2023Uas6Context _context;
    
    public PlantsController(DatabaseNeePortal2023Uas6Context context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ElectricityProductionPlant>>> GetElectricityProductionPlants()
    {
        if (_context.ElectricityProductionPlants == null)
        {
            return NotFound();
        }

        var plantList = await _context.ElectricityProductionPlants
            .ToListAsync();
    
        if (plantList == null)
        {
            return NotFound();
        }
        
        var plantMList = new List<ElectricityProductionPlant>();
        
        foreach (var plant in plantList)
        {
            plantMList.Add(plant.ConvertToPlants());
        }
        
        return plantMList;
    }
    
   
}