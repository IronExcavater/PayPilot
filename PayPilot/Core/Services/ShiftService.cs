using PayPilot.Core.Dtos;

namespace PayPilot.Core.Services;

public class ShiftService : IShiftService
{
    public Task<ShiftReadDto?> GetAsync(int id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<ShiftReadDto> CreateAsync(ShiftCreateDto dto, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<ShiftReadDto> UpdateAsync(int id, ShiftUpdateDto dto, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task SoftDeleteAsync(int id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}