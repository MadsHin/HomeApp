using HomeApp.Application.Common.Interfaces;
using MediatR;

namespace HomeApp.Application.HouseholdTasks.Commands;

public class ReopenHouseholdTaskHandler(IAppDbContext dbContext) : IRequestHandler<ReopenHouseholdTaskCommand>
{
    public async Task Handle(ReopenHouseholdTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await dbContext.HouseholdTasks.FindAsync([request.Id], cancellationToken);

        if (task is null)
            return;

        task.IsCompleted = false;
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
