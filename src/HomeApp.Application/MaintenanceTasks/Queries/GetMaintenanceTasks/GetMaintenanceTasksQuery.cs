using MediatR;

namespace HomeApp.Application.MaintenanceTasks.Queries;

public record GetMaintenanceTasksQuery : IRequest<List<MaintenanceTaskDto>>;
