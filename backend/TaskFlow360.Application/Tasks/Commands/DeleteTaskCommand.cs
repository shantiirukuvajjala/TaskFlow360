using MediatR;

namespace TaskFlow360.Application.Tasks.Commands;

public class DeleteTaskCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public DeleteTaskCommand(Guid id) => Id = id;
}
