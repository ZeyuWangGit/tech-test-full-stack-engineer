namespace Hipages.Tradies.Persistence;

public class TradiesDbContext : DbContext
{
    public TradiesDbContext(DbContextOptions<TradiesDbContext> options)
        : base(options)
    {
    }

    public DbSet<Job> Jobs => Set<Job>();
    public DbSet<Suburb> Suburbs => Set<Suburb>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SuburbConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new JobConfiguration());
    }
}