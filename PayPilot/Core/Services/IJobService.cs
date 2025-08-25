using PayPilot.Core.Domain;
using PayPilot.Core.Dtos;

namespace PayPilot.Core.Services;

public interface IJobService
{
    Task<JobReadDto?> GetAsync(int id, CancellationToken ct = default);
    Task<JobReadDto> CreateAsync(JobCreateDto dto, CancellationToken ct = default);
    Task<JobReadDto> UpdateAsync(int id, JobUpdateDto dto, CancellationToken ct = default);
    Task SoftDeleteAsync(int id, byte[] version, CancellationToken ct = default);
    Task DeleteAsync(int id, byte[] version, CancellationToken ct = default);
}