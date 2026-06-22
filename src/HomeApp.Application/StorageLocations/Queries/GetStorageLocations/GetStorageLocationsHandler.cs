using HomeApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeApp.Application.StorageLocations.Queries.GetStorageLocations;

public class GetStorageLocationsHandler(IAppDbContext dbContext)
    : IRequestHandler<GetStorageLocationsQuery, List<StorageLocationDto>>
{
    public async Task<List<StorageLocationDto>> Handle(GetStorageLocationsQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.StorageLocations
            .OrderBy(s => s.Name)
            .Select(s => new StorageLocationDto(s.Id, s.Name, s.Notes))
            .ToListAsync(cancellationToken);
    }
}
