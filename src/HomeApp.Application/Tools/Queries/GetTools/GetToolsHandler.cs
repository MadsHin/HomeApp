using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.Tools.Queries;

public class GetToolsHandler(IAppDbContext dbContext) : IRequestHandler<GetToolsQuery, List<ToolDto>>
{
    public async Task<List<ToolDto>> Handle(GetToolsQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.Tools
            .OrderBy(t => t.SortOrder)
            .ThenByDescending(t => t.CreatedAt)
            .Select(t => new ToolDto(t.Id, t.Name, t.Category, t.Icon, t.Notes, t.SortOrder, t.Status, t.StatusNote))
            .ToListAsync(cancellationToken);
    }
}
