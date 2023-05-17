using ValidationException = Hipages.Tradies.Application.Exceptions.ValidationException;

namespace Hipages.Tradies.Application.Features.Jobs.Commands.UpdateJob;

public class UpdateJobCommandHandler: IRequestHandler<UpdateJobCommand>
{
    private readonly IMapper _mapper;
    private readonly IJobRepository _jobRepository;
    public UpdateJobCommandHandler(IMapper mapper, IJobRepository jobRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _jobRepository = jobRepository ?? throw new ArgumentNullException(nameof(jobRepository));
    }
    public async Task Handle(UpdateJobCommand request, CancellationToken cancellationToken)
    {
        var jobToUpdate = await _jobRepository.GetByIdAsync(request.Id);

        if (jobToUpdate == null)
        {
            throw new NotFoundException(nameof(Job), request.Id);
        }

        var validator = new UpdateJobCommandValidator();

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
        {
            throw new ValidationException(validationResult);
        }

        _mapper.Map(request, jobToUpdate, typeof(UpdateJobCommand), typeof(Job));

        //TODO Check the suburb and category, if not exist, create new entity
        //jobToUpdate.Suburb.Name = request.SuburbName;
        //jobToUpdate.Suburb.Postcode = request.Postcode;
        //jobToUpdate.Category.Name = request.CategoryName;

        await _jobRepository.UpdateAsync(jobToUpdate);
    }
}