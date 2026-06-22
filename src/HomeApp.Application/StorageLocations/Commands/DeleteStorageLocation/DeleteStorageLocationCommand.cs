using MediatR;

namespace HomeApp.Application.StorageLocations.Commands.DeleteStorageLocation;

public record DeleteStorageLocationCommand(Guid Id) : IRequest;
