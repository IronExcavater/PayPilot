using PayPilot.Core.Domain;

namespace PayPilot.Core.Services;

public interface IJobService
{
    Task<Job?> GetAsync(int id, CancellationToken ct = default);
    Task<Job> CreateAsync(int userId, CancellationToken ct = default);
    Task<Job> UpdateAsync(Job job, int userId, CancellationToken ct = default);
    Task<Job> DeleteAsync(Job job, int userId, CancellationToken ct = default);
}