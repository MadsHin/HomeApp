using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.StorageLocations.Commands.UpdateStorageLocation;

public class UpdateStorageLocationHandler(IAppDbContext dbContext)
    : IRequestHandler<UpdateStorageLocationCommand>
{
    public async Task Handle(UpdateStorageLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await dbContext.StorageLocations
            .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
        if (location is null) return;

        location.Name = request.Name;
        location.Notes = request.Notes;

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
