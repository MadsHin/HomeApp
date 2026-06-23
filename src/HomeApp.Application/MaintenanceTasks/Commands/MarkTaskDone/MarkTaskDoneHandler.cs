using HomeApp.Application.Common.Interfaces;
using MediatR;

namespace HomeApp.Application.MaintenanceTasks.Commands;

public class MarkTaskDoneHandler(IAppDbContext dbContext)
    : IRequestHandler<MarkTaskDoneCommand>
{
    public async Task Handle(MarkTaskDoneCommand request, CancellationToken cancellationToken)
    {
        var task = await dbContext.MaintenanceTasks.FindAsync([request.Id], cancellationToken);
        if (task is null) return;

        DateOnly today = DateOnly.FromDateTime(DateTime.Today);
        DateOnly? currentNextDue = MaintenanceTaskSchedule.NextDue(task, today);

        task.LastDone = today;

        // Advance the schedule anchor past the current upcoming occurrence so that
        // marking done early (or late) always moves to the next cycle, not the same one.
        task.ScheduleAnchor = currentNextDue.HasValue && currentNextDue.Value >= today
            ? currentNextDue.Value   // done early or on time — anchor at the scheduled date
            : today;                 // done late — anchor at today, next cycle from now

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
