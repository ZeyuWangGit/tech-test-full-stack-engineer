namespace Hipages.Tradies.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobsController : ControllerBase
{
    private readonly IMediator _mediator;

    public JobsController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetJobs([FromQuery] GetJobListQuery query)
    {
        var response = await _mediator.Send(query).ConfigureAwait(false);
        return Ok(response);
    }

    [HttpPut("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> UpdateJobStatus(int id, [FromBody] UpdateJobCommand model)
    {
        model.Id = id;
        await _mediator.Send(model).ConfigureAwait(false);
        return NoContent();
    }
}