using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Commands;

public class UpdateTimelineEventHandler(IAppDbContext dbContext) : IRequestHandler<UpdateTimelineEventCommand>
{
    public async Task Handle(UpdateTimelineEventCommand request, CancellationToken cancellationToken)
    {
        ProjectTimelineEvent? ev = await dbContext.ProjectTimelineEvents
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        if (ev is null) return;

        ev.Title = request.Title;
        ev.Date = request.Date;

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
