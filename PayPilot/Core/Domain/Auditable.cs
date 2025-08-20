namespace PayPilot.Core.Domain;

public class Auditable
{
    public Guid Id { get; set; }

    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Guid? UpdateBy { get; set; }
    public DateTime? UpdateAt { get; set; }
}