using PayPilot.Core.Domain;
using PayPilot.Core.Dtos;

namespace PayPilot.Core.Mapping;

public static class JobMapper
{
    public static JobReadDto ToDto(this Job job) => new()
    {
        Id = job.Id, Title = job.Title
    };

    public static Job Apply(this JobCreateDto dto, int userId)
    {
        return new Job()
        {
            UserId = userId,
            Title = dto.Title,
        };
    }

    public static Job Apply(this JobUpdateDto dto, Job job)
    {
        job.Title = dto.Title ?? job.Title;
        return job;
    }
}