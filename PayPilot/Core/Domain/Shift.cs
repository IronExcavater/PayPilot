namespace PayPilot.Core.Domain;

public class Shift : Auditable
{
    public Job Job { get; set; }
    public Guid JobId { get; set; }

    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string? Title { get; set; }
}