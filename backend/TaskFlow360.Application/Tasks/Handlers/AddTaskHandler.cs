using MediatR;
using TaskFlow360.Application.DTOs;
using TaskFlow360.Application.Tasks.Commands;
using TaskFlow360.Domain.Entities;
using TaskFlow360.Domain.Interfaces;

namespace TaskFlow360.Application.Tasks.Handlers;

public class AddTaskHandler : IRequestHandler<AddTaskCommand, TaskDto>
{
    private readonly ITaskRepository _repository;

    public AddTaskHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<TaskDto> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new TaskItem
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            DueDate = request.DueDate,
            IsCompleted = false
        };

        await _repository.AddAsync(task);

        return new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            DueDate = task.DueDate,
            IsCompleted = task.IsCompleted
        };
    }
}
