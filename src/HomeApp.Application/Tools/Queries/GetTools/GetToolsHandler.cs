using HomeApp.Application.Common.Interfaces;
using HomeApp.Application.Tools.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.Tools.Queries.GetTools;

public class GetToolsHandler(IAppDbContext dbContext) : IRequestHandler<GetToolsQuery, List<ToolDto>>
{
    public async Task<List<ToolDto>> Handle(GetToolsQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.Tools
            .OrderBy(t => t.SortOrder)
            .ThenByDescending(t => t.CreatedAt)
            .Select(t => new ToolDto(
                t.Id, t.Name, t.Category, t.Icon, t.Notes, t.SortOrder, t.Status, t.StatusNote,
                t.StorageLocationId,
                t.StorageLocation != null ? t.StorageLocation.Name : null))
            .ToListAsync(cancellationToken);
    }
}
