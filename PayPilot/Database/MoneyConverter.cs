using System.Globalization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaMoney;

namespace PayPilot.Database;

public static class MoneyConverter
{
    private static string Serialize(Money m) =>
        m.Amount.ToString(CultureInfo.InvariantCulture) + ":" + m.Currency.Code;

    private static Money Deserialize(string s)
    {
        var parts = s.Split(':');
        return new Money(decimal.Parse(parts[0]), Currency.FromCode(parts[1]));
    }

    public static readonly ValueConverter<Money, string> MoneyToString =
        new(m => Serialize(m), s => Deserialize(s));
}