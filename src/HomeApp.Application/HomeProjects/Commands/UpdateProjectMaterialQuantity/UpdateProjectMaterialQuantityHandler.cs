using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Commands;

public class UpdateProjectMaterialQuantityHandler(IAppDbContext dbContext)
    : IRequestHandler<UpdateProjectMaterialQuantityCommand>
{
    public async Task Handle(UpdateProjectMaterialQuantityCommand request, CancellationToken cancellationToken)
    {
        HomeProjectMaterial? row = await dbContext.HomeProjectMaterials
            .FirstOrDefaultAsync(
                m => m.HomeProjectId == request.HomeProjectId && m.MaterialId == request.MaterialId,
                cancellationToken);

        if (row is null) return;

        row.QuantityNeeded = request.QuantityNeeded;
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
