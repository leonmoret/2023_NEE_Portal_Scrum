using API.Dto;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PlantController : ControllerBase
{
    private readonly DatabaseNeePortal2023Uas6Context _context;

    public PlantController(DatabaseNeePortal2023Uas6Context context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Plant>>> GetPlants()
    {
        var plants = await _context.ElectricityProductionPlants
            .Select(PP => new Plant { Id = PP.XtfId, X = PP.X, Y = PP.Y })
            .ToListAsync();

        return plants;
    }
}