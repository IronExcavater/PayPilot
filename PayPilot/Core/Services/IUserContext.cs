namespace PayPilot.Core.Services;

public interface IUserContext
{
    int? UserId { get; }
    int RequiredUserId => UserId ?? throw new InvalidOperationException("No context user");
    bool IsAuthenticated => UserId.HasValue;
    string? DisplayName { get; }
    string? TimeZoneId { get; }
}