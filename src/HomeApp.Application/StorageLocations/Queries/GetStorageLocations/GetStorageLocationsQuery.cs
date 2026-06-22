using MediatR;

namespace HomeApp.Application.StorageLocations.Queries.GetStorageLocations;

public record GetStorageLocationsQuery : IRequest<List<StorageLocationDto>>;
