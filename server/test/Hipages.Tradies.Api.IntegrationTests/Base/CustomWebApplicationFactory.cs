namespace Hipages.Tradies.Api.IntegrationTests.Base;

public class CustomWebApplicationFactory<TPrograme>
    : WebApplicationFactory<TPrograme> where TPrograme : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {

            // Remove the app's ApplicationDbContext registration.
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<TradiesDbContext>));
            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            // Add ApplicationDbContext using an in-memory database for testing.
            services.AddDbContext<TradiesDbContext>(options =>
            {
                options.UseInMemoryDatabase("TradiesDbContextInMemoryTest");
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var context = scopedServices.GetRequiredService<TradiesDbContext>();
            var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TPrograme>>>();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            try
            {
                Utilities.InitializeDbForTests(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error occurred seeding the database with test messages. Error: {ex.Message}");
            }
        });
    }

    public HttpClient GetAnonymousClient()
    {
        return CreateClient();
    }
}