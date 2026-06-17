using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Commands;

public class ToggleTimelineEventCompletionHandler(IAppDbContext dbContext)
    : IRequestHandler<ToggleTimelineEventCompletionCommand>
{
    public async Task Handle(ToggleTimelineEventCompletionCommand request, CancellationToken cancellationToken)
    {
        ProjectTimelineEvent? ev = await dbContext.ProjectTimelineEvents
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        if (ev is null) return;

        ev.IsCompleted = !ev.IsCompleted;
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
