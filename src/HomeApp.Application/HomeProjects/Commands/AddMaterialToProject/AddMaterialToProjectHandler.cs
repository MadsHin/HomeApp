using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public class AddMaterialToProjectHandler(IAppDbContext dbContext) : IRequestHandler<AddMaterialToProjectCommand>
{
    public async Task Handle(AddMaterialToProjectCommand request, CancellationToken cancellationToken)
    {
        HomeProjectMaterial join = new()
        {
            HomeProjectId = request.HomeProjectId,
            HomeProject = null!,
            MaterialId = request.MaterialId,
            Material = null!,
            QuantityNeeded = request.QuantityNeeded
        };

        dbContext.HomeProjectMaterials.Add(join);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
