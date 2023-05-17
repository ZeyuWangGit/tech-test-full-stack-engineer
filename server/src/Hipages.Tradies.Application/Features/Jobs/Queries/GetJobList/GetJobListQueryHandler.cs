namespace Hipages.Tradies.Application.Features.Jobs.Queries.GetJobList;

public class GetJobListQueryHandler: IRequestHandler<GetJobListQuery, List<GetJobListViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IJobRepository _jobRepository;

    public GetJobListQueryHandler(IMapper mapper, IJobRepository jobRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _jobRepository = jobRepository ?? throw new ArgumentNullException(nameof(jobRepository));
    }

    public async Task<List<GetJobListViewModel>> Handle(GetJobListQuery request, CancellationToken cancellationToken)
    {
        var allJobs = (await _jobRepository.GetJobListByStatus(request.JobStatus)).OrderBy(x => x.UpdatedAt);
        return _mapper.Map<List<GetJobListViewModel>>(allJobs);
    }
}