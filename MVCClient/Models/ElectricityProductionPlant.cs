namespace MVCClient.Models;

public class ElectricityProductionPlant
{
    public int XtfId { get; set; }

    public string Address { get; set; } = null!;

    public short PostCode { get; set; }

    public string Municipality { get; set; } = null!;

    public string Canton { get; set; } = null!;

    public DateTime BeginningOfOperation { get; set; }

    public double InitialPower { get; set; }

    public double TotalPower { get; set; }

    public string MainCategory { get; set; } = null!;

    public string SubCategory { get; set; } = null!;

    public string? PlantCategory { get; set; }

    public int? X { get; set; }

    public int? Y { get; set; }
}