using HomeApp.Application.Common.Interfaces;
using MediatR;

namespace HomeApp.Application.Materials.Commands;

public class DeleteMaterialHandler(IAppDbContext dbContext) : IRequestHandler<DeleteMaterialCommand>
{
    public async Task Handle(DeleteMaterialCommand request, CancellationToken cancellationToken)
    {
        var material = await dbContext.Materials.FindAsync([request.Id], cancellationToken);

        if (material is null)
            return;

        dbContext.Materials.Remove(material);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
