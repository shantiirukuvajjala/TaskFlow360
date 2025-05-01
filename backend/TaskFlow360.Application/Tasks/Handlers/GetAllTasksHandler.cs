using MediatR;
using TaskFlow360.Application.DTOs;
using TaskFlow360.Application.Tasks.Queries;
using TaskFlow360.Domain.Interfaces;

namespace TaskFlow360.Application.Tasks.Handlers
{
    public class GetAllTasksHandler : IRequestHandler<GetAllTasksQuery, List<TaskDto>>
    {
        private readonly ITaskRepository _repository;

        public GetAllTasksHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TaskDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _repository.GetAllAsync();
            return tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                DueDate = t.DueDate,
                IsCompleted = t.IsCompleted
            }).ToList();
        }
    }
}
