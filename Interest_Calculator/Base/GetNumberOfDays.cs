namespace Interest_Calculator.Base;

public class GetNumberOfDays
{
    public static decimal GetDays(string InterestFrequency)
    {
        switch (InterestFrequency.ToLower())
        {
            case "gün":
                return 1 / 365m; // Vade gün cinsinden
            case "ay":
                return 1 / 12m; // Vade ay cinsinden
            case "yıl":
                return 1; // Vade yıl cinsinden
            default:
                return 1;
        }
    }
}