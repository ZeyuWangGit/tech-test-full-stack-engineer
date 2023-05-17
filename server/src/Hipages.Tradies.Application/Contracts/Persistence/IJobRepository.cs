namespace Hipages.Tradies.Application.Contracts.Persistence;

public interface IJobRepository : IAsyncRepository<Job>
{
    Task<List<Job>> GetJobListByStatus(JobStatus status);
}