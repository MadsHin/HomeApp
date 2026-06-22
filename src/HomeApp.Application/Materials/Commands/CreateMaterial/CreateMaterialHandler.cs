using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.Materials.Commands;

public class CreateMaterialHandler(IAppDbContext dbContext) : IRequestHandler<CreateMaterialCommand, Guid>
{
    public async Task<Guid> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
    {
        int count = await dbContext.Materials.CountAsync(cancellationToken);

        Material material = new()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Quantity = request.Quantity,
            Unit = request.Unit,
            StorageLocationId = request.StorageLocationId,
            Notes = request.Notes,
            Icon = request.Icon,
            SortOrder = count,
            CreatedAt = DateTime.UtcNow
        };

        dbContext.Materials.Add(material);
        await dbContext.SaveChangesAsync(cancellationToken);
        return material.Id;
    }
}
