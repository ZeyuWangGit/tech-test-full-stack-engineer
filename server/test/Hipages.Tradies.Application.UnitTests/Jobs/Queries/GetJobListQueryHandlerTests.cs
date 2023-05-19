namespace Hipages.Tradies.Application.UnitTests.Jobs.Queries;

public class GetJobListQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IJobRepository> _mockJobRepository;

    public GetJobListQueryHandlerTests()
    {
        _mockJobRepository = RepositoryMocks.GetJobRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async Task GetJobListTest()
    {
        var handler = new GetJobListQueryHandler(_mapper, _mockJobRepository.Object);

        var result = await handler.Handle(new GetJobListQuery
        {
            JobStatus = JobStatus.Accepted
        }, CancellationToken.None);

        result.ShouldBeOfType<List<GetJobListViewModel>>();

        result.Count.ShouldBe(3);
    }
}