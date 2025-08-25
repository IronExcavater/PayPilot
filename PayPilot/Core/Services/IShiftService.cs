using PayPilot.Core.Domain;
using PayPilot.Core.Dtos;

namespace PayPilot.Core.Services;

public interface IShiftService
{
    Task<ShiftReadDto?> GetAsync(int id, CancellationToken ct = default);
    Task<ShiftReadDto> CreateAsync(ShiftCreateDto dto, CancellationToken ct = default);
    Task<ShiftReadDto> UpdateAsync(int id, ShiftUpdateDto dto, CancellationToken ct = default);
    Task SoftDeleteAsync(int id, CancellationToken ct = default);
    Task DeleteAsync(int id, CancellationToken ct = default);
}