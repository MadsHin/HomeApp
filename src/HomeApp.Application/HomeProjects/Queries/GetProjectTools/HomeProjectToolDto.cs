using HomeApp.Domain.Entities;

namespace HomeApp.Application.HomeProjects.Queries;

public record HomeProjectToolDto(
    Guid ToolId,
    string Name,
    string? Icon,
    string? Category,
    ToolStatus Status,
    string? StatusNote
);
