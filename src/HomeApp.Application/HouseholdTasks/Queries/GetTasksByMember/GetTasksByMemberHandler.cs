using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HouseholdTasks.Queries;

public class GetTasksByMemberHandler(IAppDbContext dbContext) : IRequestHandler<GetTasksByMemberQuery, List<HouseholdTaskDto>>
{
    public async Task<List<HouseholdTaskDto>> Handle(GetTasksByMemberQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.HouseholdTasks
            .Where(t => t.AssignedMemberId == request.MemberId)
            .Select(t => new HouseholdTaskDto(t.Id, t.Title, t.Description, t.DueDate, t.IsCompleted, t.Recurrence, t.AssignedMemberId))
            .ToListAsync(cancellationToken);
    }
}
