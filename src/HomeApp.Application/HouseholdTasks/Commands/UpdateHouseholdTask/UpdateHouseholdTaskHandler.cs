using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HouseholdTasks.Commands;

public class UpdateHouseholdTaskHandler(IAppDbContext dbContext) : IRequestHandler<UpdateHouseholdTaskCommand>
{
    public async Task Handle(UpdateHouseholdTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await dbContext.HouseholdTasks.FindAsync([request.Id], cancellationToken);

        if (task is null)
            return;

        task.Title = request.Title;
        task.Description = request.Description;
        task.DueDate = request.DueDate;
        task.Recurrence = request.Recurrence;
        task.AssignedMemberId = request.AssignedMemberId;

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
