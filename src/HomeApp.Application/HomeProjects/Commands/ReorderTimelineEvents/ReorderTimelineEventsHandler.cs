using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Commands;

public class ReorderTimelineEventsHandler(IAppDbContext dbContext) : IRequestHandler<ReorderTimelineEventsCommand>
{
    public async Task Handle(ReorderTimelineEventsCommand request, CancellationToken cancellationToken)
    {
        List<ProjectTimelineEvent> events = await dbContext.ProjectTimelineEvents
            .Where(e => request.OrderedIds.Contains(e.Id))
            .ToListAsync(cancellationToken);

        for (int i = 0; i < request.OrderedIds.Count; i++)
        {
            ProjectTimelineEvent? ev = events.FirstOrDefault(e => e.Id == request.OrderedIds[i]);
            if (ev is not null)
                ev.SortOrder = i;
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
