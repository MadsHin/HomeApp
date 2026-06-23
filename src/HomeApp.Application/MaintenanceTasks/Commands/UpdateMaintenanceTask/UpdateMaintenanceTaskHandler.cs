using HomeApp.Application.Common.Interfaces;
using MediatR;

namespace HomeApp.Application.MaintenanceTasks.Commands;

public class UpdateMaintenanceTaskHandler(IAppDbContext dbContext)
    : IRequestHandler<UpdateMaintenanceTaskCommand>
{
    public async Task Handle(UpdateMaintenanceTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await dbContext.MaintenanceTasks.FindAsync([request.Id], cancellationToken);
        if (task is null) return;

        task.Title          = request.Title;
        task.Notes          = request.Notes;
        task.LastDone       = request.LastDone;
        task.ScheduleAnchor = null; // cleared so manual LastDone drives the next cycle
        task.ScheduleType   = request.ScheduleType;
        task.IntervalMonths = request.IntervalMonths;
        task.AnnualDates    = request.AnnualDates;
        task.OneTimeDate    = request.OneTimeDate;

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
