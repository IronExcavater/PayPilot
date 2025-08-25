using Microsoft.EntityFrameworkCore;
using PayPilot.Core.Domain;
using PayPilot.Core.Dtos;
using PayPilot.Core.Mapping;
using PayPilot.Database;

namespace PayPilot.Core.Services;

public class JobService(AppDbContext db, IUserContext ctx) : IJobService
{
    public async Task<JobReadDto?> GetAsync(int id, CancellationToken ct = default)
    {
        var job = await db.Jobs
            .Include(j => j.User)
            .FirstOrDefaultAsync(x => x.Id == id, ct);
        return job?.ToDto();
    }

    public async Task<JobReadDto> CreateAsync(JobCreateDto dto, CancellationToken ct = default)
    {
        var job = dto.Apply(ctx.RequiredUserId);

        db.Jobs.Add(job);
        await db.SaveChangesAsync(ct);
        return job.ToDto();
    }

    public async Task<JobReadDto> UpdateAsync(int id, JobUpdateDto dto, CancellationToken ct = default)
    {
        var job = await GetJobAsync(id, ct);

        dto.Apply(job);
        await db.SaveChangesAsync(ct);
        return job.ToDto();
    }

    public async Task SoftDeleteAsync(int id, CancellationToken ct = default)
    {
        var job = await GetJobAsync(id, ct);

        job.Status = AuditStatus.Inactive;
        await db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        var job = await GetJobAsync(id, ct);


    }

    private async Task<Job> GetJobAsync(int id, CancellationToken ct = default)
    {
        var job = await db.Jobs.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (job is null) throw new KeyNotFoundException($"Job {id} not found.");
        return job;
    }
}