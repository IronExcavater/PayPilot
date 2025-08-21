using System.ComponentModel.DataAnnotations;

namespace PayPilot.Core.Domain;

public class Auditable
{
    [Key]
    public int Id { get; set; }

    public int CreatedBy { get; set; }
    public User CreatedByUser { get; set; }
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;

    public int? UpdatedBy { get; set; }
    public User? UpdatedByUser { get; set; }
    public DateTime? UpdatedUtc { get; set; }
}