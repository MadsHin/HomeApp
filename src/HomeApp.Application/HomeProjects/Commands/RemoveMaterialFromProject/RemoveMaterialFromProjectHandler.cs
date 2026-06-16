using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.HomeProjects.Commands;

public class RemoveMaterialFromProjectHandler(IAppDbContext dbContext) : IRequestHandler<RemoveMaterialFromProjectCommand>
{
    public async Task Handle(RemoveMaterialFromProjectCommand request, CancellationToken cancellationToken)
    {
        var join = await dbContext.HomeProjectMaterials
            .FirstOrDefaultAsync(m => m.HomeProjectId == request.HomeProjectId && m.MaterialId == request.MaterialId, cancellationToken);

        if (join is null)
            return;

        dbContext.HomeProjectMaterials.Remove(join);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
