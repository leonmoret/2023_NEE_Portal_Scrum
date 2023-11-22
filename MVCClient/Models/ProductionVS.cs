namespace MVCClient.Models;

public class ProductionVS
{
    public int Gwh { get; set; }
    public int Gwh_Total { get; set; }
    public int Year { get; set; }
    public string SubCategory { get; set; }
    
    
    public ProductionVS(int gwh, int gwh_Total, int year, string subCategory)
    {
        Gwh = gwh;
        Gwh_Total = gwh_Total;
        Year = year;
        SubCategory = subCategory;
    }
}