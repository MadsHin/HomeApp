using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Queries;

public class GetProjectLinksHandler(IAppDbContext dbContext)
    : IRequestHandler<GetProjectLinksQuery, List<ProjectLinkDto>>
{
    public async Task<List<ProjectLinkDto>> Handle(
        GetProjectLinksQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.ProjectLinks
            .Where(l => l.HomeProjectId == request.ProjectId)
            .Select(l => new ProjectLinkDto(l.Id, l.Label, l.Url))
            .ToListAsync(cancellationToken);
    }
}
