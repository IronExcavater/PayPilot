using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayPilot.Core.Domain;

public class Shift : Auditable
{
    [Required] public required int JobId { get; set; }
    [ForeignKey(nameof(JobId))] public Job Job { get; set; }

    public DateTime StartUtc { get; set; }
    public DateTime EndUtc { get; set; }

    [Required, MaxLength(64)] public required string Title { get; set; }
}