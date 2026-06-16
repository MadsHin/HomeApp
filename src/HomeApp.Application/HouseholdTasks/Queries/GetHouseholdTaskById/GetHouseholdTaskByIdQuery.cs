using MediatR;

namespace HomeApp.Application.HouseholdTasks.Queries;

public record GetHouseholdTaskByIdQuery(Guid Id) : IRequest<HouseholdTaskDto?>;
