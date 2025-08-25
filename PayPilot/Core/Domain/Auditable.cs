using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayPilot.Core.Domain;

public class Auditable
{
    [Key] public int Id { get; set; }
    [Timestamp] public byte[] Version { get; set; } = Array.Empty<byte>();

    public AuditStatus Status { get; set; }

    [Required] public int CreatedBy { get; set; }
    [ForeignKey(nameof(CreatedBy))] public User CreatedByUser { get; set; }
    public DateTime CreatedUtc { get; set; }

    public int? UpdatedBy { get; set; }
    [ForeignKey(nameof(UpdatedBy))] public User? UpdatedByUser { get; set; }
    public DateTime? UpdatedUtc { get; set; }
}

public enum AuditStatus
{
    Active,
    Inactive
}