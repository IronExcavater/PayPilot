namespace PayPilot.Core.Domain;

public class User : Auditable
{
    public required string DisplayName { get; set; }
    public string? TimeZone { get; set; }
    public string? Email { get; set; }
}