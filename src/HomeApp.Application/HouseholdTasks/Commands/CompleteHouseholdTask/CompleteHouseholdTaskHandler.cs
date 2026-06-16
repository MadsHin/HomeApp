using HomeApp.Application.Common.Interfaces;
using MediatR;

namespace HomeApp.Application.HouseholdTasks.Commands;

public class CompleteHouseholdTaskHandler(IAppDbContext dbContext) : IRequestHandler<CompleteHouseholdTaskCommand>
{
    public async Task Handle(CompleteHouseholdTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await dbContext.HouseholdTasks.FindAsync([request.Id], cancellationToken);

        if (task is null)
            return;

        task.IsCompleted = true;
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
