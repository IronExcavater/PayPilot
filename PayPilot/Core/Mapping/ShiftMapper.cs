using PayPilot.Core.Domain;
using PayPilot.Core.Dtos;

namespace PayPilot.Core.Mapping;

public static class ShiftMapper
{
    public static ShiftReadDto ToDto(this Shift e) => new()
    {
        Id = e.Id, Title = e.Title, StartUtc = e.StartUtc, EndUtc = e.EndUtc
    };

    public static void Apply(this Shift e, ShiftCreateDto d)
    {
        e.Title = d.Title;
    }

    public static void Apply(this Shift e, ShiftUpdateDto d)
    {
        e.Title = d.Title ?? e.Title;
    }
}