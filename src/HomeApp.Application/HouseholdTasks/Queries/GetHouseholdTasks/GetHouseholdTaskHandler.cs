using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HouseholdTasks.Queries;

public class GetHouseholdTasksHandler(IAppDbContext dbContext) : IRequestHandler<GetHouseholdTasksQuery, List<HouseholdTaskDto>>
{
    public async Task<List<HouseholdTaskDto>> Handle(GetHouseholdTasksQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.HouseholdTasks
            .Select(t => new HouseholdTaskDto(t.Id, t.Title, t.Description, t.DueDate, t.IsCompleted, t.Recurrence, t.AssignedMemberId))
            .ToListAsync(cancellationToken);
    }

}