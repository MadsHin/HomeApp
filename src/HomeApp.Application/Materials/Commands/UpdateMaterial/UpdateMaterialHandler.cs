using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;

namespace HomeApp.Application.Materials.Commands;

public class UpdateMaterialHandler(IAppDbContext dbContext) : IRequestHandler<UpdateMaterialCommand>
{
    public async Task Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
    {
        Material? material = await dbContext.Materials.FindAsync([request.Id], cancellationToken);

        if (material is null) return;

        material.Name = request.Name;
        material.Quantity = request.Quantity;
        material.Unit = request.Unit;
        material.Location = request.Location;
        material.Notes = request.Notes;
        material.Icon = request.Icon;

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
