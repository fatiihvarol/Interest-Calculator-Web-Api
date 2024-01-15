namespace Interest_Calculator.Base.Helpers;

public class GetNumberOfCompoundingPeriods
{
    public  static decimal Get(string interestFrequency)
    {
        switch (interestFrequency.ToLower())
        {
            case "gün":
                return 365m;
            case "ay":
                return 12m;
            case "yıl":
                return 1m;
            default:
                return 1m;
        }
    }
}