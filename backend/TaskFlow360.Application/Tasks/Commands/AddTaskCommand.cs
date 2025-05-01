using MediatR;
using TaskFlow360.Application.DTOs;

namespace TaskFlow360.Application.Tasks.Commands;

public class AddTaskCommand : IRequest<TaskDto>
{
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
}