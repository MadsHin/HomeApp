using MediatR;

namespace HomeApp.Application.StorageLocations.Commands.UpdateStorageLocation;

public record UpdateStorageLocationCommand(Guid Id, string Name, string? Notes) : IRequest;
