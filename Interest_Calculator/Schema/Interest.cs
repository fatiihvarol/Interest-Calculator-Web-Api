namespace Interest_Calculator.Schema;

public class InterestRequest
{
    public decimal Principal { get; set; }
    public decimal InterestRate { get; set; }
    public int Maturity { get; set; }
    public string? InterestFrequency { get; set; }
}
public class InterestResponse
{
    public decimal InterestIncome { get; set; }
    public decimal TotalBalance { get; set; }
}