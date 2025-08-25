namespace PayPilot.Core.Dtos;

public sealed class ShiftReadDto
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public required string Title { get; set; }
    public required DateTime StartUtc { get; set; }
    public required DateTime EndUtc { get; set; }
}

public sealed class ShiftCreateDto
{
    public required string Title { get; set; }
    public required DateTime StartUtc { get; set; }
    public required DateTime EndUtc { get; set; }
}

public sealed class ShiftUpdateDto
{
    public string? Title { get; set; }
    public DateTime? StartUtc { get; set; }
    public DateTime? EndUtc { get; set; }

    public required byte[] RowVersion { get; set; }
}