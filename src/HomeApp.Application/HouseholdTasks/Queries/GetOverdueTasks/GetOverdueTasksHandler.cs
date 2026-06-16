using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HouseholdTasks.Queries;

public class GetOverdueTasksHandler(IAppDbContext dbContext) : IRequestHandler<GetOverdueTasksQuery, List<HouseholdTaskDto>>
{
    public async Task<List<HouseholdTaskDto>> Handle(GetOverdueTasksQuery request, CancellationToken cancellationToken)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);

        return await dbContext.HouseholdTasks
            .Where(t => t.DueDate < today && !t.IsCompleted)
            .Select(t => new HouseholdTaskDto(t.Id, t.Title, t.Description, t.DueDate, t.IsCompleted, t.Recurrence, t.AssignedMemberId))
            .ToListAsync(cancellationToken);
    }
}
