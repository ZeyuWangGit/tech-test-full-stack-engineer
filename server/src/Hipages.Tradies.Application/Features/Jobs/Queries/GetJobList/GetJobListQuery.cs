namespace Hipages.Tradies.Application.Features.Jobs.Queries.GetJobList;

public class GetJobListQuery : IRequest<List<GetJobListViewModel>>
{
    public JobStatus JobStatus { get; set; }
}