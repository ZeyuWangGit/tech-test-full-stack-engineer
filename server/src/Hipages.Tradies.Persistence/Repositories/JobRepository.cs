namespace Hipages.Tradies.Persistence.Repositories;

public class JobRepository : BaseRepository<Job>, IJobRepository
{
    public JobRepository(TradiesDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Job>> GetJobListByStatus(JobStatus status)
    {
        var result = await DbContext.Jobs.Where(x => x.Status == status)
            .Include(i => i.Category)
            .Include(i => i.Suburb)
            .ToListAsync();

        return result;
    }
}