using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.MaintenanceTasks.Queries;

public class GetMaintenanceTasksHandler(IAppDbContext dbContext)
    : IRequestHandler<GetMaintenanceTasksQuery, List<MaintenanceTaskDto>>
{
    public async Task<List<MaintenanceTaskDto>> Handle(
        GetMaintenanceTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks = await dbContext.MaintenanceTasks
            .OrderBy(t => t.Title)
            .ToListAsync(cancellationToken);

        DateOnly today = DateOnly.FromDateTime(DateTime.Today);

        return tasks
            .Select(t => new MaintenanceTaskDto(
                t.Id, t.Title, t.Notes, t.LastDone,
                t.ScheduleType, t.IntervalMonths, t.AnnualDates, t.OneTimeDate,
                MaintenanceTaskSchedule.NextDue(t, today)))
            .OrderBy(t => t.NextDue ?? DateOnly.MaxValue)
            .ToList();
    }
}
