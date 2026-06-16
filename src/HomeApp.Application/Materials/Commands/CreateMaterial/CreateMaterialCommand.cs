using MediatR;

namespace HomeApp.Application.Materials.Commands;

public record CreateMaterialCommand(
    string Name,
    decimal? Quantity,
    string? Unit,
    string? Location,
    string? Notes,
    string? Icon
) : IRequest<Guid>;
