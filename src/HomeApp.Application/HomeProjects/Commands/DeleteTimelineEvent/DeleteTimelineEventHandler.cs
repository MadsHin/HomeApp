using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Commands;

public class DeleteTimelineEventHandler(IAppDbContext dbContext) : IRequestHandler<DeleteTimelineEventCommand>
{
    public async Task Handle(DeleteTimelineEventCommand request, CancellationToken cancellationToken)
    {
        ProjectTimelineEvent? ev = await dbContext.ProjectTimelineEvents
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        if (ev is null) return;

        dbContext.ProjectTimelineEvents.Remove(ev);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
