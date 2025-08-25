using System.ComponentModel.DataAnnotations;

namespace PayPilot.Core.Domain;

public class User : Auditable
{
    [Required, MaxLength(64)] public required string DisplayName { get; set; }
    [MaxLength(64)] public string? Email { get; set; }
}