namespace PayPilot.Core.Services;

public class UserContext : IUserContext
{
    public bool IsAuthenticated { get; init; }
    public int? UserId { get; init; }
    public string? DisplayName { get; init; }
    public string? TimeZoneId { get; init; }
}