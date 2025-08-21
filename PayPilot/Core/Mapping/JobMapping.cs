using PayPilot.Core.Domain;
using PayPilot.Core.DTO;

namespace PayPilot.Core.Mapping;

public static class JobMapping
{
    public static IQueryable<JobDto> ToDto(this IQueryable<Job> q) =>
        q.Select(j => new JobDto(
            j.Id, j.Title, j.))
}