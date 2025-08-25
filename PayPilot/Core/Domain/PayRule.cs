using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NodaMoney;

namespace PayPilot.Core.Domain;

public class PayRule : Auditable
{
    [Required] public required int JobId { get; set; }
    [ForeignKey(nameof(JobId))] public Job Job { get; set; }

    public DateTime? FromUtc { get; set; }
    public DateTime? ToUtc { get; set; }

    [Required] public required Money Money { get; set; }
    [Required] public required RuleOperation Operation { get; set; }
    [Required] public required RuleCondition Condition { get; set; }
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