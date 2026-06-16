using HomeApp.Domain.Enums;

namespace HomeApp.Application.HomeProjects.Queries;

public record HomeProjectDto(
    Guid Id,
    string Title,
    string? Description,
    ProjectStatus Status,
    decimal? Budget,
    DateOnly? StartDate,
    DateOnly? CompletedDate
);
