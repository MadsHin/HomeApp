using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Queries;

public class GetProjectToolsHandler(IAppDbContext dbContext) : IRequestHandler<GetProjectToolsQuery, List<HomeProjectToolDto>>
{
    public async Task<List<HomeProjectToolDto>> Handle(GetProjectToolsQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.HomeProjectTools
            .Where(pt => pt.HomeProjectId == request.HomeProjectId)
            .Join(dbContext.Tools, pt => pt.ToolId, t => t.Id,
                (pt, t) => new HomeProjectToolDto(t.Id, t.Name, t.Icon, t.Category, t.Status, t.StatusNote))
            .ToListAsync(cancellationToken);
    }
}
