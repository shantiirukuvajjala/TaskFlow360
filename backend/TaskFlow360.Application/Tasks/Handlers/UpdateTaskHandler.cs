using MediatR;
using TaskFlow360.Application.DTOs;
using TaskFlow360.Application.Tasks.Commands;
using TaskFlow360.Domain.Interfaces;

namespace TaskFlow360.Application.Tasks.Handlers;

public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, TaskDto?>
{
    private readonly ITaskRepository _repository;

    public UpdateTaskHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<TaskDto?> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _repository.GetByIdAsync(request.Id);
        if (task == null) return null;

        task.Title = request.Title;
        task.Description = request.Description;
        task.DueDate = request.DueDate;
        task.IsCompleted = request.IsCompleted;

        await _repository.UpdateAsync(task);

        return new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            DueDate = task.DueDate,
            IsCompleted = task.IsCompleted
        };
    }
}
