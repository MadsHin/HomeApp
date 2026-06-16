using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.Materials.Commands;

public class ReorderMaterialsHandler(IAppDbContext dbContext) : IRequestHandler<ReorderMaterialsCommand>
{
    public async Task Handle(ReorderMaterialsCommand request, CancellationToken cancellationToken)
    {
        List<Material> materials = await dbContext.Materials
            .Where(m => request.OrderedIds.Contains(m.Id))
            .ToListAsync(cancellationToken);

        for (int i = 0; i < request.OrderedIds.Count; i++)
        {
            Material? material = materials.FirstOrDefault(m => m.Id == request.OrderedIds[i]);
            if (material is not null)
                material.SortOrder = i;
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
