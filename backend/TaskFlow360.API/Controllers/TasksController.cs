using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskFlow360.Application.DTOs;
using TaskFlow360.Application.Tasks.Commands;
using TaskFlow360.Application.Tasks.Queries;

namespace TaskFlow360.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<TaskDto>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllTasksQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<TaskDto>> Create([FromBody] AddTaskCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TaskDto>> Update(Guid id, [FromBody] UpdateTaskCommand command)
    {
        if (id != command.Id)
            return BadRequest("Mismatched task ID.");

        var result = await _mediator.Send(command);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteTaskCommand(id));
        if (!result)
            return NotFound();

        return NoContent();
    }
}

