using NodaMoney;

namespace PayPilot.Core.Dtos;

public sealed class JobReadDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
}

public sealed class JobCreateDto
{
    public required string Title { get; set; }
}

public sealed class JobUpdateDto
{
    public string? Title { get; set; }

    public required byte[] Version { get; set; }
}