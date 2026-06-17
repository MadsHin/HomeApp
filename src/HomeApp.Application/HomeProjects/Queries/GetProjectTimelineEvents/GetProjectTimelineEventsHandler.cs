using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Queries;

public class GetProjectTimelineEventsHandler(IAppDbContext dbContext)
    : IRequestHandler<GetProjectTimelineEventsQuery, List<ProjectTimelineEventDto>>
{
    public async Task<List<ProjectTimelineEventDto>> Handle(
        GetProjectTimelineEventsQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.ProjectTimelineEvents
            .Where(e => e.HomeProjectId == request.ProjectId)
            .OrderBy(e => e.SortOrder)
            .ThenBy(e => e.CreatedAt)
            .Select(e => new ProjectTimelineEventDto(e.Id, e.Title, e.Date, e.SortOrder))
            .ToListAsync(cancellationToken);
    }
}
