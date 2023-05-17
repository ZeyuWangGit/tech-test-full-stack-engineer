namespace Hipages.Tradies.Persistence.Repositories;

public class JobRepository : BaseRepository<Job>, IJobRepository
{
    public JobRepository(TradiesDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Job>> GetJobListByStatus(JobStatus status)
    {
        return await DbContext.Jobs.Where(x => x.Status == status).ToListAsync();
    }
}