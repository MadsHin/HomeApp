using MediatR;

namespace HomeApp.Application.Materials.Commands;

public record UpdateMaterialCommand(
    Guid Id,
    string Name,
    decimal? Quantity,
    string? Unit,
    Guid? StorageLocationId,
    string? Notes,
    string? Icon
) : IRequest;
