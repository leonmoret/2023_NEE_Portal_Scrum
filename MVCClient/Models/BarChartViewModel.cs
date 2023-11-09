namespace MVCClient.Models;

public class BarChartViewModel
{

    public double PVkWhThisYear { get; set; }
    public double WTkWhThisYear { get; set; }
    public double PVkWhLastYear { get; set; }
    public double WTkWhLastYear { get; set; }
    
    public BarChartViewModel(double pvkWhThisYear, double wTkWhThisYear, double pvkWhLastYear, double wTkWhLastYear)
    {
        PVkWhThisYear = pvkWhThisYear;
        WTkWhThisYear = wTkWhThisYear;
        PVkWhLastYear = pvkWhLastYear;
        WTkWhLastYear = wTkWhLastYear;
    }
 
}