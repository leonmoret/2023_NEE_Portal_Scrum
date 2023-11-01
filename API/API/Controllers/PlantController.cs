using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PlantController : ControllerBase
{
    private readonly Context _context;

    public PlantController(Context context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Plant>>> GetPlants()
    {
        return await _context.Plants.ToListAsync();
    }
}