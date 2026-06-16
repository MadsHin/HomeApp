using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public class AddMaterialToProjectHandler(IAppDbContext dbContext) : IRequestHandler<AddMaterialToProjectCommand>
{
    public async Task Handle(AddMaterialToProjectCommand request, CancellationToken cancellationToken)
    {
        var join = new HomeProjectMaterial
        {
            HomeProjectId = request.HomeProjectId,
            HomeProject = null!,
            MaterialId = request.MaterialId,
            Material = null!,
            Quantity = request.Quantity
        };

        dbContext.HomeProjectMaterials.Add(join);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
