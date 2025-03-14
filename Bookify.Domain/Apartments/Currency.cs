namespace Bookify.Domain.Apartments;

public record Currency
{
    private static readonly Currency Usd = new("USD");
    private static readonly Currency Eru = new("ERU");
    private Currency(string code) {
        Code = code;
    }
    public string Code {  get; init; }

    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(c => c.Code == code) ??
            throw new ApplicationException("The Currency Code Is Invalied");
    }
    public static readonly IReadOnlyCollection<Currency>All = new[]
    { Usd, Eru };
}
