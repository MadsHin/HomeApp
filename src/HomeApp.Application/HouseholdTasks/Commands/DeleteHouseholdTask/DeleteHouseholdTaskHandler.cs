using HomeApp.Application.Common.Interfaces;
using MediatR;

namespace HomeApp.Application.HouseholdTasks.Commands;

public class DeleteHouseholdTaskHandler(IAppDbContext dbContext) : IRequestHandler<DeleteHouseholdTaskCommand>
{
    public async Task Handle(DeleteHouseholdTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await dbContext.HouseholdTasks.FindAsync([request.Id], cancellationToken);

        if (task is null)
            return;

        dbContext.HouseholdTasks.Remove(task);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
