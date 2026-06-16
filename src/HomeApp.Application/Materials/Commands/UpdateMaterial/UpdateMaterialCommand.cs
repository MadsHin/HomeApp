using MediatR;

namespace HomeApp.Application.Materials.Commands;

public record UpdateMaterialCommand(
    Guid Id,
    string Name,
    decimal? Quantity,
    string? Unit,
    string? Location,
    string? Notes,
    string? Icon
) : IRequest;
