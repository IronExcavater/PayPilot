namespace PayPilot.Core.DTO;

public sealed record ShiftDto(
    int Id,
    string Title,
    DateTime StartUtc,
    DateTime EndUtc,
    int JobId,
    string JobTitle);