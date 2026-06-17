using MediatR;

namespace HomeApp.Application.HomeProjects.Commands;

public record UpdateProjectMaterialQuantityCommand(
    Guid HomeProjectId,
    Guid MaterialId,
    decimal? QuantityNeeded
) : IRequest;
