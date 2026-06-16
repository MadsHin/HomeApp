using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;

namespace HomeApp.Application.Materials.Commands;

public class AdjustMaterialQuantityHandler(IAppDbContext dbContext) : IRequestHandler<AdjustMaterialQuantityCommand>
{
    public async Task Handle(AdjustMaterialQuantityCommand request, CancellationToken cancellationToken)
    {
        Material? material = await dbContext.Materials.FindAsync([request.Id], cancellationToken);

        if (material is null) return;

        material.Quantity = Math.Max(0, (material.Quantity ?? 0) + request.Delta);

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
