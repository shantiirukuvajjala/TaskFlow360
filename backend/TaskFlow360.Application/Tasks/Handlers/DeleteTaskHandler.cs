using MediatR;
using TaskFlow360.Application.Tasks.Commands;
using TaskFlow360.Domain.Interfaces;

namespace TaskFlow360.Application.Tasks.Handlers;

public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, bool>
{
    private readonly ITaskRepository _repository;

    public DeleteTaskHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _repository.GetByIdAsync(request.Id);
        if (task == null) return false;

        await _repository.DeleteAsync(request.Id);
        return true;
    }
}

