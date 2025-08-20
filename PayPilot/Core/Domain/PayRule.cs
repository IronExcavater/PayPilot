using Microsoft.EntityFrameworkCore;

namespace PayPilot.Core.Domain;

public class PayRule : Auditable
{
    public Job Job { get; set; }
    public Guid JobId { get; set; }

    public DateTime EffectiveFrom { get; set; }
    public DateTime? EffectiveTo { get; set; }

    public decimal Amount { get; set; }
    public RuleOperation Operation { get; set; }
    public required RuleCondition Condition { get; set; }
}

public enum RuleOperation
{
    Multiply,   // pay *= Amount
    Add,        // pay += Amount
    Subtract    // pay -= Amount
}

[Owned]
public class RuleCondition
{
    public byte? DayMask { get; set; }
    public TimeOnly? StartTime { get; set; }
    public TimeOnly? EndTime { get; set; }
}