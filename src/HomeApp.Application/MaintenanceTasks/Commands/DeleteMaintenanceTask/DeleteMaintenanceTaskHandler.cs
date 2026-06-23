using HomeApp.Application.Common.Interfaces;
using MediatR;

namespace HomeApp.Application.MaintenanceTasks.Commands;

public class DeleteMaintenanceTaskHandler(IAppDbContext dbContext)
    : IRequestHandler<DeleteMaintenanceTaskCommand>
{
    public async Task Handle(DeleteMaintenanceTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await dbContext.MaintenanceTasks.FindAsync([request.Id], cancellationToken);
        if (task is null) return;

        dbContext.MaintenanceTasks.Remove(task);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
