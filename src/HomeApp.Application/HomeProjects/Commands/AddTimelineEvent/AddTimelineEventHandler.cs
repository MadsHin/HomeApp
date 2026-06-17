using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Commands;

public class AddTimelineEventHandler(IAppDbContext dbContext) : IRequestHandler<AddTimelineEventCommand>
{
    public async Task Handle(AddTimelineEventCommand request, CancellationToken cancellationToken)
    {
        int maxSort = await dbContext.ProjectTimelineEvents
            .Where(e => e.HomeProjectId == request.HomeProjectId)
            .Select(e => (int?)e.SortOrder)
            .MaxAsync(cancellationToken) ?? -1;

        dbContext.ProjectTimelineEvents.Add(new ProjectTimelineEvent
        {
            Id = Guid.NewGuid(),
            HomeProjectId = request.HomeProjectId,
            Title = request.Title,
            Date = request.Date,
            SortOrder = maxSort + 1,
            CreatedAt = DateTime.UtcNow
        });

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
