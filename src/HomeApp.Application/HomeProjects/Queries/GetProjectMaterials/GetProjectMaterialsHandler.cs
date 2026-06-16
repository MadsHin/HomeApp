using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Queries;

public class GetProjectMaterialsHandler(IAppDbContext dbContext)
    : IRequestHandler<GetProjectMaterialsQuery, List<ProjectMaterialDto>>
{
    public async Task<List<ProjectMaterialDto>> Handle(
        GetProjectMaterialsQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.HomeProjectMaterials
            .Where(m => m.HomeProjectId == request.ProjectId)
            .Select(m => new ProjectMaterialDto(
                m.MaterialId,
                m.Material.Name,
                m.Material.Icon,
                m.Material.Unit,
                m.QuantityNeeded,
                m.Material.Quantity))
            .ToListAsync(cancellationToken);
    }
}
