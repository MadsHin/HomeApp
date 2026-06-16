namespace HomeApp.Application.HouseholdTasks.Queries;
using MediatR;

public record GetHouseholdTasksQuery() : IRequest<List<HouseholdTaskDto>>;