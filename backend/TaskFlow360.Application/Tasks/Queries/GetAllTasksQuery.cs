using MediatR;
using TaskFlow360.Application.DTOs;

namespace TaskFlow360.Application.Tasks.Queries
{
    public class GetAllTasksQuery : IRequest<List<TaskDto>> { }
}
