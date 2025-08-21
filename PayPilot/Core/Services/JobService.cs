using Microsoft.EntityFrameworkCore;
using PayPilot.Core.Domain;
using PayPilot.Database;

namespace PayPilot.Core.Services;

public class JobService(AppDbContext _db) : IJobService
{

    public Task<Job?> GetAsync(int id, CancellationToken ct = default)
    {
        _db.Jobs.Include(j => j.User).FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public async Task<Job> CreateAsync(int userId, CancellationToken ct = default)
    {
        var job = new Job { CreatedBy = userId };

        _db.Jobs.Add(job);
        await _db.SaveChangesAsync(ct);
    }

    public Task<Job> UpdateAsync(Job job, int userId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<Job> DeleteAsync(Job job, int userId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}