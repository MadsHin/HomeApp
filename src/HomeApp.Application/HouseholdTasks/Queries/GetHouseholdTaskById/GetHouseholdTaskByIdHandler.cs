using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HouseholdTasks.Queries;

public class GetHouseholdTaskByIdHandler(IAppDbContext dbContext) : IRequestHandler<GetHouseholdTaskByIdQuery, HouseholdTaskDto?>
{
    public async Task<HouseholdTaskDto?> Handle(GetHouseholdTaskByIdQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.HouseholdTasks
            .Where(t => t.Id == request.Id)
            .Select(t => new HouseholdTaskDto(t.Id, t.Title, t.Description, t.DueDate, t.IsCompleted, t.Recurrence, t.AssignedMemberId))
            .FirstOrDefaultAsync(cancellationToken);
    }
}
