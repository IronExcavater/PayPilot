namespace PayPilot.Core.Domain;

public class JobTitle : Auditable
{
    public int JobId { get; set; }
    public Job Job { get; set; }

    public DateTime FromUtc { get; set; }
    public DateTime? ToUtc { get; set; }
}