using HomeApp.Domain.Entities;

namespace HomeApp.Application.Tools.Queries;

public record ToolDto(
    Guid Id,
    string Name,
    string? Category,
    string? Icon,
    string? Notes,
    int SortOrder,
    ToolStatus Status,
    string? StatusNote
);
