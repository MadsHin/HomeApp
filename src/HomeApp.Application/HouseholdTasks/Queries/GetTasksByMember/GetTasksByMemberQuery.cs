using MediatR;

namespace HomeApp.Application.HouseholdTasks.Queries;

public record GetTasksByMemberQuery(Guid MemberId) : IRequest<List<HouseholdTaskDto>>;
