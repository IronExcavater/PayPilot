using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayPilot.Core.Domain;

public class Job : Auditable
{
    [Required] public required int UserId { get; set; }
    [ForeignKey(nameof(UserId))] public User User { get; set; }

    public DateTime FromUtc  { get; set; }
    public DateTime? ToUtc { get; set; }
    [Required, MaxLength(64)] public required string Title { get; set; }
}