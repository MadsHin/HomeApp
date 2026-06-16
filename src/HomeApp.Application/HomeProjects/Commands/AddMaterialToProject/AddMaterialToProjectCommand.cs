using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record AddMaterialToProjectCommand(
    Guid HomeProjectId,
    Guid MaterialId,
    string? Quantity
) : IRequest;
