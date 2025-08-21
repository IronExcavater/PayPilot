namespace PayPilot.Core.DTO;

public sealed class JobDto
{
    public int Id { get; set; }

    public int JobTitleId { get; }
    public string? Title { get; set; }
}