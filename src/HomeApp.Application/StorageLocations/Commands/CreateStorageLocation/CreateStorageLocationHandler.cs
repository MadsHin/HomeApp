using HomeApp.Application.Common.Interfaces;
using HomeApp.Domain.Entities;
using MediatR;

namespace HomeApp.Application.StorageLocations.Commands.CreateStorageLocation;

public class CreateStorageLocationHandler(IAppDbContext dbContext)
    : IRequestHandler<CreateStorageLocationCommand, Guid>
{
    public async Task<Guid> Handle(CreateStorageLocationCommand request, CancellationToken cancellationToken)
    {
        StorageLocation location = new()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Notes = request.Notes
        };

        dbContext.StorageLocations.Add(location);
        await dbContext.SaveChangesAsync(cancellationToken);
        return location.Id;
    }
}
