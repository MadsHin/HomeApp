using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;

namespace HomeApp.Application.MaintenanceTasks.Commands;

public class CreateMaintenanceTaskHandler(IAppDbContext dbContext)
    : IRequestHandler<CreateMaintenanceTaskCommand, Guid>
{
    public async Task<Guid> Handle(CreateMaintenanceTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new MaintenanceTask
        {
            Id             = Guid.NewGuid(),
            Title          = request.Title,
            Notes          = request.Notes,
            LastDone       = request.LastDone,
            ScheduleType   = request.ScheduleType,
            IntervalMonths = request.IntervalMonths,
            AnnualDates    = request.AnnualDates,
            OneTimeDate    = request.OneTimeDate
        };

        dbContext.MaintenanceTasks.Add(task);
        await dbContext.SaveChangesAsync(cancellationToken);
        return task.Id;
    }
}
