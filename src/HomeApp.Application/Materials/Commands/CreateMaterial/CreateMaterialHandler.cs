using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;

namespace HomeApp.Application.Materials.Commands;

public class CreateMaterialHandler(IAppDbContext dbContext) : IRequestHandler<CreateMaterialCommand, Guid>
{
    public async Task<Guid> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
    {
        Material material = new()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Quantity = request.Quantity,
            Unit = request.Unit,
            Location = request.Location,
            Notes = request.Notes,
            Icon = request.Icon
        };

        dbContext.Materials.Add(material);
        await dbContext.SaveChangesAsync(cancellationToken);
        return material.Id;
    }
}
