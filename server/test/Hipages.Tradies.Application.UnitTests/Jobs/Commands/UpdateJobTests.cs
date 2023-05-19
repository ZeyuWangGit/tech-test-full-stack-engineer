using Hipages.Tradies.Application.Features.Jobs.Commands.UpdateJob;
using Hipages.Tradies.Application.Features.Jobs.Commands.UpdateJobStatus;

namespace Hipages.Tradies.Application.UnitTests.Jobs.Commands;

public class UpdateJobTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IJobRepository> _mockJobRepository;

    public UpdateJobTests()
    {
        _mockJobRepository = RepositoryMocks.GetJobRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async Task Handle_ValidCategory_AddedToCategoriesRepo()
    {
        var handler = new UpdateJobCommandHandler(_mapper, _mockJobRepository.Object);

        await handler.Handle(new UpdateJobCommand()
        {
            Id = 1,
            Status = JobStatus.Declined,
            SuburbName = "Surry Hills",
            CategoryName = "Plumbing",
            ContactEmail = "luke@mailinator.com",
            ContactName = "Luke Skywalker",
            ContactPhone = "0412345678",
            Description = "12345",
            Postcode = "2010",
            Price = 20
        }, CancellationToken.None);

        var allCategories = await _mockJobRepository.Object.ListAllAsync();
        allCategories.First(o => o.Id == 1).Status.ShouldBe(JobStatus.Declined);
        allCategories.Count.ShouldBe(3);
    }
}