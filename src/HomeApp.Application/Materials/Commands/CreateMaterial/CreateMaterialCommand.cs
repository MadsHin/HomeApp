using MediatR;

namespace HomeApp.Application.Materials.Commands;

public record CreateMaterialCommand(
    string Name,
    decimal? Quantity,
    string? Unit,
    Guid? StorageLocationId,
    string? Notes,
    string? Icon,
    decimal? UnitPrice
) : IRequest<Guid>;
