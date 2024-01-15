namespace Interest_Calculator.Entity;

public class Interest
{
    public decimal Principal { get; set; }
    public decimal InterestRate { get; set; }
    public int Maturity { get; set; }
    public string? InterestFrequency { get; set; }
}