﻿using API.Extension;
using API.Models;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<ActionResult<IEnumerable<ProductionVS>>> GetProductionVS()
    {
        if (_context.ProductionVs == null)
        {
            return NotFound();
        }

        var plantList = await _context.ProductionVs.Where(p => p.Year == 2017 || p.Year == 2018).Where(p => p.SubCategory == "subcat_1" || p.SubCategory == "subcat_2")
            .ToListAsync();


        if (plantList == null)
        {
            return NotFound();
        }
        

        var plantMList = new List<ProductionVS>();
        
         foreach (var plant in plantList)
         {
             plantMList.Add(plant.ConvertToProductionVS());
         }
        
        return plantMList;
    }


}