using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.StorageLocations.Commands.DeleteStorageLocation;

public class DeleteStorageLocationHandler(IAppDbContext dbContext)
    : IRequestHandler<DeleteStorageLocationCommand>
{
    public async Task Handle(DeleteStorageLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await dbContext.StorageLocations
            .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
        if (location is null) return;

        dbContext.StorageLocations.Remove(location);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
