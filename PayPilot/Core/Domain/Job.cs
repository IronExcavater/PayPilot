namespace PayPilot.Core.Domain;

public class Job
{
    public Guid Id { get; set; }

    public User User { get; set; }
    public Guid UserId { get; set; }
}