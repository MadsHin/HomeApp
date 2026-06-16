using MediatR;

namespace HomeApp.Application.HouseholdTasks.Queries;

public record GetOverdueTasksQuery() : IRequest<List<HouseholdTaskDto>>;
