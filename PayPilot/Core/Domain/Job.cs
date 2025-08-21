namespace PayPilot.Core.Domain;

public class Job : Auditable
{
    public int UserId { get; set; }
    public User User { get; set; }

    public DateTime FromUtc  { get; set; }
    public DateTime ToUtc { get; set; }
}