using MediatR;

namespace HomeApp.Application.StorageLocations.Commands.CreateStorageLocation;

public record CreateStorageLocationCommand(string Name, string? Notes) : IRequest<Guid>;
